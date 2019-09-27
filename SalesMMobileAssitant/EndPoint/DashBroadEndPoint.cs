using SalesMMobileAssitant.Helper;
using SalesMMobileAssitant.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SalesMMobileAssitant.EndPoint
{
    public class DashBroadEndPoint
    {
        private static DashBroadEndPoint _Ins;

        public static DashBroadEndPoint Ins
        {
            get
            {
                if (_Ins == null)
                    _Ins = new DashBroadEndPoint();
                return DashBroadEndPoint._Ins;
            }
            private set
            {
                DashBroadEndPoint._Ins = value;
            }
        }
        public async Task<List<Order>> LoadOrders()
        {
            string url = "http://webapi.local/api/Order/orders";

            using (HttpResponseMessage response = await APIHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsAsync<List<Order>>().Result;

                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);

                }
            }
        }

        public async Task<List<EpicorOrder>> GetListOrder()
        {
            string url = "http://webapi.local/api/EpicorOrder/Orders";

            using (HttpResponseMessage response = await APIHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsAsync<List<EpicorOrder>>().Result;


                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);

                }
            }
        }
    }
}
