using BusinessData;
using BusinessModels.Franchise;
using BusinessServices;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
    }
}