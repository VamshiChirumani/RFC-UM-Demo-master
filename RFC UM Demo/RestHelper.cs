using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RFC_UM_Demo
{
    public class RestHelper
    {
        public static readonly string baseurl = "http://172.16.160.90:8888/data-services/rest/";

        public static async Task<string> GetTagBlinks()
        {
            using(HttpClient client = new HttpClient())

            {
                var byteArray = Encoding.ASCII.GetBytes("admin:admin");
                var header = new AuthenticationHeaderValue(
                           "Basic", Convert.ToBase64String(byteArray));
                client.DefaultRequestHeaders.Authorization = header;
                using (HttpResponseMessage res = await client.GetAsync(baseurl+ "tagblinks/region/efe86b7b-37fa-4e1b-a5b5-267f9667d3ab"))
                {
                    using(HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            return data;
                        }
                    }
                }
            }
            return string.Empty;
        }
    }
}
