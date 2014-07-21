using System.Net.Http;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641
using KeepFit.Phone.Core;

namespace KeepFit.Phone
{
    public sealed partial class MainPage : Page
    {
        private readonly ApiConnectorService apiConnectorService;
        public MainPage()
        {
            InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Required;
            apiConnectorService = new ApiConnectorService();
        }

        private async void GetJsonButton_OnClick(object sender, RoutedEventArgs e)
        {
            var client = new HttpClient();
            JsonTextBlock.Text = await apiConnectorService.TryRequestAsync(client, "tiunovmike@gmail.com", "xf3z54dlc");
        }
    }
}
