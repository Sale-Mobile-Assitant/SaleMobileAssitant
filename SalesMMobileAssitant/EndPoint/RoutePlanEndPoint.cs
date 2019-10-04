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
    public class RoutePlanEndPoint
    {
        private static RoutePlanEndPoint _Ins;

        public static RoutePlanEndPoint Ins
        {
            get
            {
                if (_Ins == null)
                    _Ins = new RoutePlanEndPoint();
                return RoutePlanEndPoint._Ins;
            }
            private set
            {
                RoutePlanEndPoint._Ins = value;
            }
        }

        public async Task<bool> Put(RoutePlan routePlan,string CompID,string EmplID,int CustID,string DatePlan)
        {
            string url = string.Format("http://webapi.local/api/RoutePlan/{0},{1},{2},{3}",CompID,EmplID,CustID,DatePlan);


            var json = JsonConvert.SerializeObject(routePlan);

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
        public async Task<bool> Delete(string CompID, string EmplID, int CustID, string DatePlan)
        {
            string url = string.Format("http://webapi.local/api/RoutePlan/{0},{1},{2},{3}", CompID, EmplID, CustID, DatePlan);

            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Delete, url);
          

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
