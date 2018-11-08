using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service.Communication
{
    public static class Service
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<T> PostService<T>(object content, string url) {
            try
            {
                var json = JsonConvert.SerializeObject(content);

                var response = await client.PostAsync(string.Format("{0}/{1}", Constants.uri, url),
                    new StringContent(JsonConvert.SerializeObject(content, Formatting.None,
                    new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    })
                    , Encoding.UTF8
                    , "application/json"));


                if (response.IsSuccessStatusCode)
                {
                    var responseContentString = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<T>(responseContentString);
                    return result;
                }
                throw new Exception("Error");
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public static async Task<T> GetService<T>(string url)
        {
            var response = await client.GetAsync(string.Format("{0}/{1}", Constants.uri, url));
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseString);
        }

    }
}
