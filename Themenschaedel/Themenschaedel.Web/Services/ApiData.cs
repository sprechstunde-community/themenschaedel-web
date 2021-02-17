using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
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
        }

        public async Task<Episode> GetEpisode(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<GetEpisodeWorkaround> GetEpisodes(int count, int page)
        {
            var response = await _httpClient.GetAsync($"http://api.themenschaedel.darlor.de/episodes?page={page}&per_page={count}");
            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                GetEpisodeWorkaround ep = JsonConvert.DeserializeObject<GetEpisodeWorkaround>(json);
                return ep;
            }
            return null;
        }
    }
}
