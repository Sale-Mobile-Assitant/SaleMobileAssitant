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
    public class ProductGroupEndPoint
    {
        private static ProductGroupEndPoint _Ins;

        public static ProductGroupEndPoint Ins
        {
            get
            {
                if (_Ins == null)
                    _Ins = new ProductGroupEndPoint();
                return ProductGroupEndPoint._Ins;
            }
            private set
            {
                ProductGroupEndPoint._Ins = value;
            }
        }

        public async Task<List<EpicorProductGroup>> GetProductGroupFromEpicor()
        {
            string url = "http://webapi.local/api/EpicorProductGroup/productgroups";

            using (HttpResponseMessage response = await APIHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsAsync<List<EpicorProductGroup>>().Result;

                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);

                }
            }
        }
        public async Task<bool> PostProductGroupToDB(ProductGroup product)
        {
            string url = "http://webapi.local/api/ProductGroup";


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
