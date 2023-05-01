using BusinessData;
using BusinessServices;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BusinessMVC2.Controllers
{
    public class ApiController : Controller
    {
        [HttpPost]
        public async Task<ActionResult> SaveClientsFromGoogleSheet(List<Client> clients)
        {
            // Assuming the ClientService has a constructor that accepts a Guid userId parameter
            // Replace this line with the correct logic for getting the user ID
            var userId = Guid.Parse(User.Identity.GetUserId());

            // Create an instance of the ClientService
            var clientService = new ClientService(userId);

            // Save the clients to the database
            // You need to add a new method in your ClientService class to save multiple clients at once
            // For example: await clientService.SaveClientsAsync(clients);

            return Json(new { success = true });
        }
    }
}