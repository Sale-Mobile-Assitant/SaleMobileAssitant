using Newtonsoft.Json;
using SalesMMobileAssitant.Helper;
using SalesMMobileAssitant.Model;
using SalesMMobileAssitant.Model.EpicorModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SalesMMobileAssitant.EndPoint
{
    public class ProductEndPoint
    {
        private static ProductEndPoint _Ins;

        public static ProductEndPoint Ins
        {
            get
            {
                if (_Ins == null)
                    _Ins = new ProductEndPoint();
                return ProductEndPoint._Ins;
            }
            private set
            {
                ProductEndPoint._Ins = value;
            }
        }

        public async Task<List<EpicorProduct>> GetProductFromEpicor()
        {
            string url = "http://webapi.local/api/EpicorProduct/Products";

            using (HttpResponseMessage response = await APIHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsAsync<List<EpicorProduct>>().Result;

                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
        public async Task<bool> PostProductToDB(Product product)
        {
            string url = "http://webapi.local/api/Product";


            var json = JsonConvert.SerializeObject(product);

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
