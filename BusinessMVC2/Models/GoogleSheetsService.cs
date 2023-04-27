using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace BusinessMVC2.Models
{
    public class GoogleSheetsService
    {
        private static readonly string KeyFilePath = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["GoogleSheetsCredentialsPath"]);

        public static SheetsService GetSheetsService()
        {
            // Load the service account key
            var credential = GoogleCredential.FromFile(KeyFilePath)
                .CreateScoped(SheetsService.Scope.SpreadsheetsReadonly);

            // Create an authorized Sheets API client
            var service = new SheetsService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential,
                ApplicationName = "Smash-Dashboard"
            });

            return service;
        }
    }
}