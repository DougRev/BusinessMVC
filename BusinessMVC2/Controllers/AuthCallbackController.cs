using Google.Apis.Auth.OAuth2.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using BusinessMVC2.Models;
using Google.Apis.Auth.OAuth2.Mvc;

namespace BusinessMVC2.Controllers
{
    public class AuthCallbackController : Google.Apis.Auth.OAuth2.Mvc.Controllers.AuthCallbackController
    {
        protected override Google.Apis.Auth.OAuth2.Mvc.FlowMetadata FlowData
        {
            get { return new Models.AppFlowMetadata(); }
        }

        public override async Task<ActionResult> IndexAsync(AuthorizationCodeResponseUrl url, CancellationToken cancellationToken)
        {
            // Call the base method to handle the callback and store the tokens.
            ActionResult result = await base.IndexAsync(url, cancellationToken);

            // Store the UserCredential in the Session
            var authResult = await new AuthorizationCodeMvcApp(this, new AppFlowMetadata()).AuthorizeAsync(cancellationToken);
            Session["UserCredential"] = authResult.Credential;

            // Redirect the user back to the original page they were on.
            return RedirectToAction("ImportClientsFromGoogleSheet", "Client");
        }

    }
}