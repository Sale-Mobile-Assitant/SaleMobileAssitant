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
        public async Task<List<T>> GetDataFromDB2<T>(string urlDB)
        {

            string url = "http://webapi.local/api/" + urlDB;

            HttpResponseMessage response = APIHelper.ApiClient.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<List<T>>();
                return result;
            }
            return null;

        }

        public bool TestConection(string url)
        {
            try
            {
                using (HttpResponseMessage response = APIHelper.ApiClient.GetAsync(url).Result)
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
            catch (Exception)
            {
                return false;
            }
           
        }

        public async Task<List<T>> GetDataFromDB<T>(string urlDB)
        {
            if (!string.IsNullOrEmpty(Properties.Settings.Default.URIAPI))
            {
                string url = Properties.Settings.Default.URIAPI + urlDB;

                using (HttpResponseMessage response = APIHelper.ApiClient.GetAsync(url).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsAsync<List<T>>();

                        return result;
                    }
                    else
                    {
                        throw new Exception(response.ReasonPhrase);
                    }
                }
            }
            return null;
        }
        public async Task<string> GetDataFromEpicor2(string urlEpicor)
        {
            string url = "http://webapi.local/api/" + urlEpicor;

            using (HttpResponseMessage response =  APIHelper.ApiClient.GetAsync(url).Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<List<T>> GetDataFromEpicor<T>(string urlEpicor)
        {

            if (!string.IsNullOrEmpty(Properties.Settings.Default.URIAPI))
            {
                string url = Properties.Settings.Default.URIAPI + urlEpicor;

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
            return null;
        }
        public async Task<string> PostDataToEpicor2<T>(string urlDB, T value)
        {
            if (!string.IsNullOrEmpty(Properties.Settings.Default.URIAPI))
            {
                string url = Properties.Settings.Default.URIAPI + urlDB;

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
                        var result = await response.Content.ReadAsStringAsync();
                        return result;
                    }
                    else
                    {
                        return response.StatusCode.ToString();
                    }
                }
            }
            return null;
        }


        public async Task<bool> PostDataToEpicor<T>(string urlDB, T value)
        {
            if (!string.IsNullOrEmpty(Properties.Settings.Default.URIAPI))
            {
                string url = Properties.Settings.Default.URIAPI + urlDB;

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
            return false; 
        }
        public async Task<bool> PostDataToDB<T>(string urlDB,T value)
        {
            if (!string.IsNullOrEmpty(Properties.Settings.Default.URIAPI))
            {
                string url = Properties.Settings.Default.URIAPI + urlDB;

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
            return false;

        }
     

    }
}
