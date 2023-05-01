using Google.Apis.Auth.OAuth2.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Google.Apis.Auth.OAuth2.Requests;
using Google.Apis.Auth.OAuth2.Responses;

namespace BusinessMVC2.Controllers
{
    public class AuthCallbackController : Google.Apis.Auth.OAuth2.Mvc.Controllers.AuthCallbackController
    {
        protected override Google.Apis.Auth.OAuth2.Mvc.FlowMetadata FlowData
        {
            get { return new Models.AppFlowMetadata(); }
        }

        public override async Task<ActionResult> IndexAsync(AuthorizationCodeResponseUrl url,CancellationToken cancellationToken)
        {
            // Call the base method to handle the callback and store the tokens.
            ActionResult result = await base.IndexAsync(url,cancellationToken);

            // You can add any additional logic after the callback is handled, if necessary.

            // Redirect the user back to the original page they were on.
            return RedirectToAction("ImportClientsFromGoogleSheet", "Client");
        }

    }
}