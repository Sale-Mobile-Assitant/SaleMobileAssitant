using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SalesMMobileAssitant.Helper
{
    public class GeneralMethodEpicor
    {
        private static GeneralMethodEpicor _Ins;

        public static GeneralMethodEpicor Ins
        {
            get
            {
                if (_Ins == null)
                    _Ins = new GeneralMethodEpicor();
                return GeneralMethodEpicor._Ins;
            }
            private set
            {
                GeneralMethodEpicor._Ins = value;
            }
        }

        public string GetOrderDetail()
        {
            string strResponseValue = "";
            string url = "https://portal.3ssoft.com.vn:7443/SRV03Epicor10Test/api/v1/Erp.BO.SalesOrderSvc/OrderDtls?$select=OrderNum%2COrderLine&$filter=OrderNum%20ge%205440";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            String authHeaer = System.Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes("epicor" + ":" + "epicor"));
            request.Headers.Add("Authorization", "basic" + " " + authHeaer);

            HttpWebResponse response = null;
            try
            {
                response = (HttpWebResponse)request.GetResponse();

                using (Stream responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (StreamReader reader =  new StreamReader(responseStream))
                        {
                            strResponseValue =  reader.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                strResponseValue = "{\"errorMessages\":[\"" + ex.Message.ToString() + "\"],\"errors\":{}}";
            }
            finally
            {
                if (response != null)
                {
                    ((IDisposable)response).Dispose();
                }
            }

            return strResponseValue;
        }

        public async Task<bool> DeleteOrder(int OrderNum)
        {
            string url = string.Format("https://portal.3ssoft.com.vn:7443/SRV03Epicor10Test/api/v1/Erp.BO.SalesOrderSvc/SalesOrders(EPIC06,{0})",OrderNum);

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, url);

            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", "epicor", "epicor"))));


            using (HttpResponseMessage response = await APIHelper.ApiClient.SendAsync(request))
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

        public async Task<bool> DeleteOrderDetail(int OrderNum,int OrderLine)
        {
            string url = string.Format("https://portal.3ssoft.com.vn:7443/SRV03Epicor10Test/api/v1/Erp.BO.SalesOrderSvc/OrderDtls(EPIC03,{0},{1})", OrderNum, OrderLine);

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, url);

            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", "epicor", "epicor"))));


            using (HttpResponseMessage response = await APIHelper.ApiClient.SendAsync(request))
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
