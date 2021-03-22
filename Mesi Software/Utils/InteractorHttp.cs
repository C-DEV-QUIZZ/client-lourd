using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mesi_Software.Tools
{
    public static class InteractorHttp
    {
        private static HttpClient _interactor = new HttpClient();


        public static string Get(string url)
        {
            return _interactor.GetAsync(url).Result.Content.ReadAsStringAsync().Result;
        }        
        public static string Post(string url,StringContent data)
        {
            return _interactor.PostAsync(url, data).Result.Content.ReadAsStringAsync().Result;
        }
    }
}
