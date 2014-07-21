using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace KeepFit.Phone.Core
{
    public interface IApiConnector
    {
        Task<string> TryRequestAsync(HttpClient client, string userName, string password);
        Task<T> TryRequestAsync<T>(HttpClient client, string userName, string password);
        AuthenticationHeaderValue CreateBasicCredentials(string userName, string password);

    }
}
