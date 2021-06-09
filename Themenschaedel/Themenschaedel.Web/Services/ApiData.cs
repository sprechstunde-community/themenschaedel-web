using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Sentry;
using Themenschaedel.Shared.Props;
using Themenschaedel.Web.Services.Interfaces;

namespace Themenschaedel.Web.Services
{
    public class ApiData : IData
    {
        private readonly HttpClient _httpClient;

        public ApiData(HttpClient httpClient)
        {
            _httpClient = httpClient;

            RequestCSRFToken();
        }

        private void RequestCSRFToken()
        {
            string csrf = "";
            
            Uri uriExecution = new Uri($"{_httpClient.BaseAddress}sanctum/csrf-cookie");
            CookieContainer cookies = new CookieContainer();
            
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uriExecution);
            request.Method = "GET";
            request.ContentType = "application/json; charset=utf-8";
            request.CookieContainer = cookies;
            
            var response = request.GetResponse();
            CookieCollection cookieCollection = cookies.GetCookies(uriExecution);
            for (int i = 0; i < cookieCollection.Count; i++)
            {
                if (cookieCollection[i].Name == "XSRF-TOKEN")
                {
                    csrf = cookieCollection[i].Value;
                }
            }
            
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("X-XSRF-TOKEN", csrf); 
        }

        public async Task<Episode> GetEpisode(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<string> Login(string email, string password)
        {
            //string json = "{ "+ email +", "+ password +"  }";
            
            //Uri uriExecution = new Uri("https://api.themenschaedel.darlor.de/users");
            
            //var response = await _httpClient.PostAsync(uriExecution, json);

            //string responseString = await response.Content.ReadAsStringAsync();

            //return responseString;
            
            throw new NotImplementedException();
        }

        public async Task<GetEpisodeWorkaround> GetEpisodes(int count, int page)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_httpClient.BaseAddress}episodes?page={page}&per_page={count}");
                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;
                    GetEpisodeWorkaround ep = JsonConvert.DeserializeObject<GetEpisodeWorkaround>(json);
                    return ep;
                }
                return null;
            }
            catch (Exception e)
            {
                SentrySdk.CaptureException(e);
                throw;
            }
        }
    }
}
