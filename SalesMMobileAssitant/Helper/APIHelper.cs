﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net;

namespace SalesMMobileAssitant.Helper
{
    public static class APIHelper
    {
        public static HttpClient ApiClient { get; set; }

        public static void InitializeClient()
        {
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            ApiClient = new HttpClient();

            if (!string.IsNullOrEmpty(Properties.Settings.Default.URIAPI))
            {
                string url = Properties.Settings.Default.URIAPI;
                ApiClient.BaseAddress = new Uri(url);
            }
           
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

    }
}
