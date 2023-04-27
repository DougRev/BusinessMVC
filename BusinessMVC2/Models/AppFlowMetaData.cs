using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Mvc;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Google.Apis.Util.Store;
using System.IO;
using System.Configuration;

namespace BusinessMVC2.Models
{
    public class AppFlowMetadata : FlowMetadata
    {
        private static readonly IAuthorizationCodeFlow flow =
         new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
         {
             ClientSecrets = GoogleClientSecrets.FromStream(new FileStream(HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["GoogleSheetsCredentialsPath"]), FileMode.Open)).Secrets,
             Scopes = new[] { SheetsService.Scope.SpreadsheetsReadonly },
             DataStore = new FileDataStore(HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["GoogleSheetsTokenFolderPath"]), true),
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