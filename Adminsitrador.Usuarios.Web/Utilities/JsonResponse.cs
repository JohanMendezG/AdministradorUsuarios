using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

namespace Adminsitrador.Usuarios.Web.Utilities
{
    public class JsonResponse
    {
        public static string GetJson(string url)
        {
            using (var httpClient = new HttpClient())
            {
                var responseAsync = Task.Run(async () =>
                {
                    using (var response = await httpClient.GetAsync(url).ConfigureAwait(false))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                            return responseString;
                        }

                        return string.Empty;
                    }
                });

                return responseAsync.Result;
            }
        }

        public static string PostJson(string url, HttpContent content)
        {
            using (var httpClient = new HttpClient())
            {
                var responseAsync = Task.Run(async () =>
                {
                    using (var response = await httpClient.PostAsync(url, content).ConfigureAwait(false))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                            return responseString;
                        }

                        return string.Empty;
                    }
                });

                return responseAsync.Result;
            }
        }
    }
}
