using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace KayaBank_WepApiCrudMVC
{
    public class GlobalVariables
    {
        public static HttpClient WepApiClient = new HttpClient();

        static GlobalVariables()
        {
            WepApiClient.BaseAddress = new Uri("http://localhost:44393/api/");
            WepApiClient.DefaultRequestHeaders.Clear();
            WepApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}