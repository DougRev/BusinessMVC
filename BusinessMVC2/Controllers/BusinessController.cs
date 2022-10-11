using BusinessModels;
using BusinessServices;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusinessMVC2.Controllers
{
    public class BusinessController : Controller
    {
        // GET: Business
        public ActionResult Index()
        {
            //This Method will display races for a specific user.
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BusinessService(userId);
            var model = service.GetBusinesses();

            return View(model);

            //return View();
        }

        public ActionResult Create()
        {
            return View();
        }
        private BusinessService CreateBusinessService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var businessService = new BusinessService(userId);
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
            var service = new BusinessService(userId);
            service.CreateBusiness(model);

            return RedirectToAction("Index");
        }

        //GET: Details
        //Race/Details/{id}
        public ActionResult Details(int id)
        {
            var svc = CreateBusinessService();
            var model = svc.GetBusinessById(id);
            return View(model);
        }


        //GET: Edit
        //Race/Edit/{id}
        public ActionResult Edit(int id)
        {
            var svc = CreateBusinessService();
            var detail = svc.GetBusinessById(id);
            var model = new BusinessEdit
            {
                BusinessId = detail.BusinessId,
                BusinessName = detail.BusinessName,
                FranchiseeId = detail.FranchiseeId,
            };
            return View(model);
        }

        //POST: Edit
        //Race/Edit/{id}
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
                TempData["SaveResult"] = "Your business has been updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your business could not be updated.");
            return View(model);
        }

        //GET: Delete
        //Race/Delete/{id}
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateBusinessService();
            var model = svc.GetBusinessById(id);
            return View(model);
        }

        //POST: Delete
        //Race/Delete/{id}
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteBusiness(int id)
        {
            var service = CreateBusinessService();
            service.DeleteBusiness(id);
            TempData["SaveResult"] = "Your Business has been deleted.";

            return RedirectToAction("Index");
        }
    }
}