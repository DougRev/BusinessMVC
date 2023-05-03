using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Mvc;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Util.Store;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace BusinessMVC2.Models
{
    public class AppFlowMetadata : FlowMetadata
    {
        private static readonly IAuthorizationCodeFlow flow =
            new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
            {
                ClientSecrets = new ClientSecrets
                {
                    ClientId = "846675010514-avrmk1feujf45l32pnt55bpsv74smkl4.apps.googleusercontent.com",
                    ClientSecret = "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"
                },
                Scopes = new[] { SheetsService.Scope.SpreadsheetsReadonly }, // Set the required scopes
                DataStore = new EntityFrameworkDataStore()
            });

        public override IAuthorizationCodeFlow Flow
        {
            get { return flow; }
        }

        public override string GetUserId(Controller controller)
        {
            // You should implement this method to get the user ID
            // from your authentication system.
            // This example just returns a fixed string.
            return "user@example.com";
        }
    }

}
