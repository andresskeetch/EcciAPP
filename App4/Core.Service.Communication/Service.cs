using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service.Communication
{
    public class Service
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task<object> PostService<T>(object content) {
            var json = JsonConvert.SerializeObject(content); 

            var response = await client.PostAsync(Constants.uri,null);

            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseString);
        }

        public async Task<object> GetService<T>(string url, string parameter)
        {
            var response = await client.GetAsync(string.Format("{0}/{1}/{2}", Constants.uri, url, parameter));
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseString);
        }

    }
}
