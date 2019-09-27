using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SalesMMobileAssitant.Helper
{
    public class GeneralMethods
    {
        private static GeneralMethods _Ins;

        public static GeneralMethods Ins
        {
            get
            {
                if (_Ins == null)
                    _Ins = new GeneralMethods();
                return GeneralMethods._Ins;
            }
            private set
            {
                GeneralMethods._Ins = value;
            }
        }

        public async Task<List<T>> GetDataFromEpicor<T>(string urlEpicor)
        {
            string url = "http://webapi.local/api/" + urlEpicor;

            using (HttpResponseMessage response = await APIHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsAsync<List<T>>().Result;

                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
        public async Task<bool> PostDataToDB<T>(string urlDB,T value)
        {
            string url = "http://webapi.local/api/" + urlDB;

            var json = JsonConvert.SerializeObject(value);

            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = content
            };

            using (HttpResponseMessage response = await APIHelper.ApiClient.SendAsync(message))
            {
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
