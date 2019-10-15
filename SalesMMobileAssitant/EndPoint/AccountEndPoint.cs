using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SalesMMobileAssitant.EndPoint
{
    public class AccountEndPoint
    {
        private static AccountEndPoint _ins;

        public static AccountEndPoint Ins
        {
            get
            {
                if (_ins == null)
                    _ins = new AccountEndPoint();
                return AccountEndPoint._ins;
            }
            private set
            {
                AccountEndPoint._ins = value;
            }
        }

        public string Get()
        {
            string strResponseValue = "";
            string url = "https://portal.3ssoft.com.vn:2443/SalesMobileAPI/api/Customer/customers";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
 
            HttpWebResponse response = null;
            try
            {
                response = (HttpWebResponse)request.GetResponse();

                using (Stream responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            strResponseValue = reader.ReadToEnd();
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
    }
}
