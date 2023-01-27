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
                FranchiseeId = detail.FranchiseeId,
                XferStation = detail.XferStation,
                ToClientDist = detail.ToClientDist,
                FromClientDist = detail.FromClientDist,
                ToHaulerDist = detail.ToHaulerDist,
                FromHaulerDist = detail.FromHaulerDist,
                LandfillDist = detail.LandfillDist,
                HaulsPerDay = detail.HaulsPerDay,
                Num2 = detail.Num2,
                
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
    }
}