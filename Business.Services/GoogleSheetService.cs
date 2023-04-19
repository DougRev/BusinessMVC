using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessServices
{
    public class GoogleSheetService
    {
        private static string[] Scopes = { SheetsService.Scope.SpreadsheetsReadonly };
        private static string ApplicationName = "Smash-Dashboard";
        private static string ClientId = "846675010514-avrmk1feujf45l32pnt55bpsv74smkl4.apps.googleusercontent.com";
        private static string ClientSecret = "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";

        public static SheetsService GetSheetsService()
        {
            var clientSecrets = new ClientSecrets()
            {
                ClientId = ClientId,
                ClientSecret = ClientSecret,
            };

            var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                clientSecrets,
                Scopes,
                "user",
                CancellationToken.None).Result;

            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            return service;
        }
    }
}
