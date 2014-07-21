using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace KeepFit.Phone
{
    public sealed partial class MainPage : Page
    {
        private const string url = "http://keepfit.ihb.by/api/management";
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

        }

        private async void GetJsonButton_OnClick(object sender, RoutedEventArgs e)
        {
            var client = new HttpClient();
            await TryRequestAsync(client, CreateBasicCredentials("tiunovmike@gmail.com", "xf3z54dlc"));
        }
        async Task TryRequestAsync(HttpClient client, AuthenticationHeaderValue authorization)
        {
            using (var request = new HttpRequestMessage(HttpMethod.Get, url))
            {
                request.Headers.Authorization = authorization;
                using (HttpResponseMessage response = await client.SendAsync(request))
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        return;
                    }

                    JsonTextBlock.Text = await response.Content.ReadAsStringAsync();
                }
            }
        }

        static AuthenticationHeaderValue CreateBasicCredentials(string userName, string password)
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


    }
}
