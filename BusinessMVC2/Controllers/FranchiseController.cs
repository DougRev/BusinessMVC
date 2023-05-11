using BusinessData;
using BusinessModels;
using BusinessModels.Franchise;
using BusinessServices;
using CsvHelper;
using Microsoft.AspNet.Identity;
using SelectPdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace BusinessMVC2.Controllers
{
    public class FranchiseController : Controller
    {

        // GET: Franchise
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FranchiseService(userId);
            var model = service.GetFranchises();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        private FranchiseService CreateFranchiseService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var franchiseService = new FranchiseService(userId);
            return franchiseService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FranchiseCreate model)
        {
            if (ModelState.IsValid)
            {
                return View(model);
            }
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FranchiseService(userId);
            service.CreateFranchise(model);

            return RedirectToAction("Index");
        }

        //GET: Details
        //Franchise/Details/{id}
        public ActionResult Details(int id)
        {
            var franchiseId = id;
            var svc = CreateFranchiseService();
            var model = svc.GetClientsByFranchiseId(id);
            return View(model);
        }


        //GET: Edit
        //Franchise/Edit/{id}
        public ActionResult Edit(int id)
        {
            var svc = CreateFranchiseService();
            var detail = svc.GetFranchiseById(id);
            var model = new FranchiseEdit
            {
                FranchiseId = detail.FranchiseId,
                FranchiseName = detail.FranchiseName,
                State = detail.State,
            };
            return View(model);
        }

        //POST: Edit
        //Franchise/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FranchiseEdit model)
        {
            var currentUserId = User.Identity.GetUserId();
            if (!ModelState.IsValid) return View(model);


            if (model.FranchiseId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateFranchiseService();

            if (service.UpdateFranchise(model))
            {
                TempData["SaveResult"] = "Your Franchise has been updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Franchise could not be updated.");
            return View(model);
        }

        //GET: Delete
        //Franchise/Delete/{id}
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateFranchiseService();
            var model = svc.GetFranchiseById(id);
            return View(model);
        }

        //POST: Delete
        //Franchise/Delete/{id}
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteFranchise(int id)
        {
            var service = CreateFranchiseService();
            service.DeleteFranchise(id);
            TempData["SaveResult"] = "Your Franchise has been deleted.";

            return RedirectToAction("Index");
        }

        // GET: List
        // Franchise/List/{id}
        public ActionResult List(int id)
        {
            var svc = CreateFranchiseService();
            var clients = svc.GetClientsByFranchiseId(id);
            var model = clients.Clients.Select(c => new BusinessListItem
            {
                BusinessId = c.BusinessId,
                BusinessName = c.BusinessName,
                FranchiseName = c.Franchise.FranchiseName,
                FacilityID = c.FacilityID,
                Address = c.Address,
                City = c.City,
                State = c.State,
                ZipCode = c.ZipCode,
                OwnerId = c.OwnerId,
            });
            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SubmitAction(FormCollection collection)
        {
            // read parameters from the webpage
            string userId = collection["UserId"];
            Guid userGuid = Guid.Parse(userId);
            int franchiseId = Convert.ToInt32(collection["FranchiseId"]);

            var svc = new FranchiseService(userGuid);
            var franchise = svc.GetFranchiseById(franchiseId);

            // Calculate the total CO2 saved for the franchise
            double totalCO2Saved = svc.GetTotalCO2SavedForFranchiseById(franchiseId);
            int states = svc.CountDistinctStatesWithClientsByFranchiseId(franchiseId);
            int locations = svc.CountClientsByFranchiseId(franchiseId);
            franchise.Locations = locations;
            franchise.TotalCO2Saved = totalCO2Saved;
            franchise.StateReach = states;

            // generate JavaScript to hide the navbar
            string script = "function hideNavbar(){var e=document.getElementsByClassName('navbar')[0];if(e){e.style.display='none';}}; hideNavbar();";

            // generate HTML code for the business details and inject JavaScript to hide the navbar
            string htmlString = RenderViewToString(ControllerContext, "~/Views/Franchise/FranchiseDetailsToPdf.cshtml", franchise, script);


            // instantiate a html to pdf converter object
            HtmlToPdf converter = new HtmlToPdf();

            string pdfPageSize = collection["DdlPageSize"];
            PdfPageSize pageSize = (PdfPageSize)Enum.Parse(typeof(PdfPageSize), pdfPageSize, true);

            string pdfOrientation = collection["DdlPageOrientation"];
            PdfPageOrientation pdfOrientationEnum = (PdfPageOrientation)Enum.Parse(typeof(PdfPageOrientation), pdfOrientation, true);

            int webPageWidth = 1024;
            try
            {
                webPageWidth = Convert.ToInt32(collection["TxtWidth"]);
            }
            catch
            {
            }

            int webPageHeight = 0;
            try
            {
                webPageHeight = Convert.ToInt32(collection["TxtHeight"]);
            }
            catch
            {
            }

            // set converter options
            converter.Options.PdfPageSize = pageSize;
            converter.Options.PdfPageOrientation = pdfOrientationEnum;
            converter.Options.WebPageWidth = webPageWidth;
            converter.Options.WebPageHeight = webPageHeight;

            // create a new pdf document converting an url
            PdfDocument doc = converter.ConvertHtmlString(htmlString, "https://businessmvc220230407125015.azurewebsites.net/");

            // save pdf document
            byte[] pdf = doc.Save();

            // close pdf document
            doc.Close();

            // return resulted pdf document
            FileResult fileResult = new FileContentResult(pdf, "application/pdf");
            fileResult.FileDownloadName = "Document.pdf";

            // Pass the total CO2 saved value to the viewbag to be displayed in the PDF
            ViewBag.TotalCO2Saved = totalCO2Saved;

            return fileResult;
        }




        protected string RenderRazorViewToString(string viewName, object model)
        {
            ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);
                return sw.GetStringBuilder().ToString();
            }
        }


        // helper method to render view to string
        private string RenderViewToString(ControllerContext context, string viewName, object model, string script)
        {
            ViewEngineResult result = ViewEngines.Engines.FindView(context, viewName, null);
            if (result.View == null)
            {
                throw new FileNotFoundException("View cannot be found.");
            }

            string viewData = "";
            using (var sw = new StringWriter())
            {
                var viewContext = new ViewContext(context, result.View, new ViewDataDictionary(model), new TempDataDictionary(), sw);
                result.View.Render(viewContext, sw);

                // Add the JavaScript code to the end of the HTML body
                var html = sw.ToString();
                html = html.Replace("</body>", $"<script>{script}</script></body>");

                viewData = html;
            }

            return viewData;
        }

    }
}