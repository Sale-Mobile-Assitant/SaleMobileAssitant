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
    public class CompanyEndPoint
    {
        private static CompanyEndPoint _Ins;

        public static CompanyEndPoint Ins
        {
            get
            {
                if (_Ins == null)
                    _Ins = new CompanyEndPoint();
                return CompanyEndPoint._Ins;
            }
            private set
            {
                CompanyEndPoint._Ins = value;
            }
        }

        public async Task<EpicorCompany> GetCompanyFromEpicor()
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
        public async Task<bool> PostCompanyToDB(Company company)
        {
            string url = "http://webapi.local/api/Company";


            var json = JsonConvert.SerializeObject(company);

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
