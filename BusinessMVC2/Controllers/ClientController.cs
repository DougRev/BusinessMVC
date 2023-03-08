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
using iTextSharp.text;
using System.Drawing.Printing;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;

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


        public class GoogleSheetsApiHelper
        {
            private readonly UserCredential _credential;

            public GoogleSheetsApiHelper(string clientId, string clientSecret, string[] scopes, string applicationName)
            {
                _credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    new ClientSecrets
                    {
                        ClientId = clientId,
                        ClientSecret = clientSecret,
                    },
                    scopes,
                    "user",
                    System.Threading.CancellationToken.None).Result;

                Service = new SheetsService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = _credential,
                    ApplicationName = applicationName,
                });
            }


            public SheetsService Service { get; }

            public List<IList<Object>> GetSheetData(string spreadsheetId, string range)
            {
                SpreadsheetsResource.ValuesResource.GetRequest getRequest = Service.Spreadsheets.Values.Get(spreadsheetId, range);
                ValueRange response = getRequest.Execute();
                List<IList<Object>> data = response.Values.ToList();
                return data;
            }
        }


        public ActionResult Create()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var svc = new FranchiseService(userId);

            ViewBag.Franchises = svc.GetFranchises().Select(f => new {
                FranchiseId = f.FranchiseId,
                FranchiseName = f.FranchiseName
            }).ToList();

            return View();
        }

        public ActionResult Quote()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ClientService(userId);
            var svc = new FranchiseService(userId);

            ViewBag.Franchises = svc.GetFranchises().Select(f => new {
                FranchiseId = f.FranchiseId,
                FranchiseName = f.FranchiseName
            }).ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Quote(BusinessCreate model)
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
                City = detail.City,
                Address = detail.Address,
                ZipCode = detail.ZipCode,
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
        public ActionResult BusinessDetailsToPdf(int id)
        {
            var userId = User.Identity.GetUserId();
            var svc = new ClientService(Guid.Parse(userId));
            var model = svc.GetBusinessById(id);

            // generate HTML code for the business details
            var htmlContent = this.RenderRazorViewToString("BusinessDetailsToPdf", model);

            ViewData.Add("TxtHtmlCode", htmlContent);

            return View(model);

        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SubmitAction(FormCollection collection)
        {
            // read parameters from the webpage
            string userId = collection["UserId"];
            Guid userGuid = Guid.Parse(userId);
            int businessId = Convert.ToInt32(collection["BusinessId"]);

            var svc = new ClientService(userGuid);
            var model = svc.GetBusinessById(businessId);

            // generate JavaScript to hide the navbar
            string script = "function hideNavbar(){var e=document.getElementsByClassName('navbar')[0];if(e){e.style.display='none';}}; hideNavbar();";

            // generate HTML code for the business details and inject JavaScript to hide the navbar
            string htmlString = RenderViewToString(ControllerContext, "~/Views/Client/BusinessDetailsToPdf.cshtml", model, script);


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
            PdfDocument doc = converter.ConvertHtmlString(htmlString, "https://localhost:44394/");

            // save pdf document
            byte[] pdf = doc.Save();

            // close pdf document
            doc.Close();

            // return resulted pdf document
            FileResult fileResult = new FileContentResult(pdf, "application/pdf");
            fileResult.FileDownloadName = "Document.pdf";
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