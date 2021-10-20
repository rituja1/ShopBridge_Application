﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace MVC
{
    public static class Global_variables
    {
        public static HttpClient WebApiClient = new HttpClient();
      static Global_variables()
        {
            WebApiClient.BaseAddress = new Uri("https://localhost:44330/api/");
            WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}