using BusinessModels;
using BusinessServices;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using SelectPdf;
using System.IO;

namespace BusinessMVC2.Controllers
{
    public class ClientController : Controller
    {
        // GET: Clients
        public ActionResult Index()
        {
            //This Method will display races for a specific user.
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ClientService(userId);
            var model = service.GetBusinesses();

            return View(model);

            //return View();
        }

        public ActionResult Create()
        {
            return View();
        }
        private ClientService CreateBusinessService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var businessService = new ClientService(userId);
            return businessService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BusinessCreate model)
        {
            if (ModelState.IsValid)
            {
                return View(model);
            }
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ClientService(userId);
            service.CreateBusiness(model);

            return RedirectToAction("Index");
        }

        //GET: Details
        //Client/Details/{id}
        public ActionResult Details(int id)
        {
            var svc = CreateBusinessService();
            var model = svc.GetBusinessById(id);
            return View(model);
        }


        //GET: Edit
        //Client/Edit/{id}
        public ActionResult Edit(int id)
        {
            var svc = CreateBusinessService();
            var detail = svc.GetBusinessById(id);
            var model = new BusinessEdit
            {
                BusinessId = detail.BusinessId,
                BusinessName = detail.BusinessName,
                State = detail.State,
                FranchiseId = detail.FranchiseId,
                Compactibility = detail.Compactibility,
                FranchiseeId = detail.FranchiseeId,
                ToClientDist = detail.ToClientDist,
                FromClientDist = detail.FromClientDist,
                ToHaulerDist = detail.ToHaulerDist,
                FromHaulerDist = detail.FromHaulerDist,
                LandfillDist = detail.LandfillDist,
                HaulsPerDay = detail.HaulsPerDay,
                NumberOfDumpsters = detail.NumberOfDumpsters,
                
                
            };
            return View(model);
        }

        //POST: Edit
        //Client/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BusinessEdit model)
        {
            var currentUserId = User.Identity.GetUserId();
            //var ownerId = model.OwnerId;

            if (!ModelState.IsValid) return View(model);


            if (model.BusinessId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateBusinessService();

            if (service.UpdateBusinesses(model))
            {
                TempData["SaveResult"] = "Your Client has been updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Client could not be updated.");
            return View(model);
        }

        //GET: Delete
        //Client/Delete/{id}
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateBusinessService();
            var model = svc.GetBusinessById(id);
            return View(model);
        }

        //POST: Delete
        //Client/Delete/{id}
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteBusiness(int id)
        {
            var service = CreateBusinessService();
            service.DeleteBusiness(id);
            TempData["SaveResult"] = "Your Client has been deleted.";

            return RedirectToAction("Index");
        }

        //Convert HTML to PDF
        public ActionResult FranchiseDetailsToPdf()
        {
            var model = new BusinessModels.Franchise.FranchiseDetails();
            // set model properties here, such as FranchiseName, Clients, etc.

            // render view to string
            string htmlString = RenderRazorViewToString("Details", model);

            ViewData.Add("TxtHtmlCode", htmlString);
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SubmitAction(FormCollection collection)
        {
            // read parameters from the webpage
            string htmlString = collection["TxtHtmlCode"];
            string baseUrl = collection["TxtBaseUrl"];

            string pdf_page_size = collection["DdlPageSize"];
            PdfPageSize pageSize = (PdfPageSize)Enum.Parse(typeof(PdfPageSize),
                pdf_page_size, true);

            string pdf_orientation = collection["DdlPageOrientation"];
            PdfPageOrientation pdfOrientation =
                (PdfPageOrientation)Enum.Parse(typeof(PdfPageOrientation),
                pdf_orientation, true);

            int webPageWidth = 1024;
            try
            {
                webPageWidth = Convert.ToInt32(collection["TxtWidth"]);
            }
            catch { }

            int webPageHeight = 0;
            try
            {
                webPageHeight = Convert.ToInt32(collection["TxtHeight"]);
            }
            catch { }

            // instantiate a html to pdf converter object
            HtmlToPdf converter = new HtmlToPdf();

            // set converter options
            converter.Options.PdfPageSize = pageSize;
            converter.Options.PdfPageOrientation = pdfOrientation;
            converter.Options.WebPageWidth = webPageWidth;
            converter.Options.WebPageHeight = webPageHeight;

            // create a new pdf document converting an url
            PdfDocument doc = converter.ConvertHtmlString(htmlString, baseUrl);

            // save pdf document
            byte[] pdf = doc.Save();

            // close pdf document
            doc.Close();

            // return resulted pdf document
            FileResult fileResult = new FileContentResult(pdf, "application/pdf");
            fileResult.FileDownloadName = "Document.pdf";
            return fileResult;
        }

        // helper method to render view to string
        public string RenderRazorViewToString(string viewName, object model)
        {
            ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext,
                    viewName);
                var viewContext = new ViewContext(ControllerContext, viewResult.View,
                    ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);
                return sw.GetStringBuilder().ToString();
            }
        }
    }

}