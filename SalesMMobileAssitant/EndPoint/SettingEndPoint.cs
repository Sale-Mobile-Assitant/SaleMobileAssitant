using SalesMMobileAssitant.Helper;
using SalesMMobileAssitant.Model.EpicorModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SalesMMobileAssitant.EndPoint
{
    public class SettingEndPoint
    {
        private static SettingEndPoint _Ins;

        public static SettingEndPoint Ins
        {
            get
            {
                if (_Ins == null)
                    _Ins = new SettingEndPoint();
                return SettingEndPoint._Ins;
            }
            private set
            {
                SettingEndPoint._Ins = value;
            }
        }
        public async Task<EpicorCompany> Company()
        {
            string url = "http://webapi.local/api/Epicorcompany/EPIC06/companies";

            using (HttpResponseMessage response = await APIHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsAsync<EpicorCompany>().Result;

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
