using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace KeepFit.Phone.Core
{
    public class ApiConnectorService : IApiConnector
    {
        private const string ApiUrl = "http://keepfit.ihb.by/api/";
        public async Task<string> TryRequestAsync(HttpClient client, string userName, string password)
        {
            using (var request = new HttpRequestMessage(HttpMethod.Get, PrepareUrl(ApiResources.Management)))
            {
                request.Headers.Authorization = CreateBasicCredentials(userName, password);
                using (HttpResponseMessage response = await client.SendAsync(request))
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        return null;
                    }

                    return await response.Content.ReadAsStringAsync();
                }
            }
        }

        public async Task<T> TryRequestAsync<T>(HttpClient client, string userName, string password)
        {
            using (var request = new HttpRequestMessage(HttpMethod.Get, PrepareUrl(ApiResources.Management)))
            {
                request.Headers.Authorization = CreateBasicCredentials(userName, password);
                using (HttpResponseMessage response = await client.SendAsync(request))
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        throw new Exception();
                    }

                    return await response.Content.ReadAsAsync<T>();
                }
            }
        }

        public AuthenticationHeaderValue CreateBasicCredentials(string userName, string password)
        {
            string toEncode = userName + ":" + password;
            // The current HTTP specification says characters here are ISO-8859-1.
            // However, the draft specification for the next version of HTTP indicates this encoding is infrequently
            // used in practice and defines behavior only for ASCII.
            Encoding encoding = Encoding.GetEncoding("iso-8859-1");
            byte[] toBase64 = encoding.GetBytes(toEncode);
            string parameter = Convert.ToBase64String(toBase64);

            return new AuthenticationHeaderValue("Basic", parameter);
        }

        private string PrepareUrl(ApiResources type)
        {
            switch (type)
            {
                case ApiResources.Management:
                    return ApiUrl + "management";
            }
            return "";
        }
    }
}
