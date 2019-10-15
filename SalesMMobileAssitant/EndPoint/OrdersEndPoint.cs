using Newtonsoft.Json;
using SalesMMobileAssitant.Helper;
using SalesMMobileAssitant.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SalesMMobileAssitant.EndPoint
{
    public class OrdersEndPoint
    {

        private static OrdersEndPoint _Ins;

        public static OrdersEndPoint Ins
        {
            get
            {
                if (_Ins == null)
                    _Ins = new OrdersEndPoint();
                return OrdersEndPoint._Ins;
            }
            private set
            {
                OrdersEndPoint._Ins = value;
            }
        }
        public async Task<bool> Put(Order order)
        {
            string url = string.Format("https://portal.3ssoft.com.vn:2443/SalesMobileAPI/api/Order");


            var json = JsonConvert.SerializeObject(order);

            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Put, url)
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
