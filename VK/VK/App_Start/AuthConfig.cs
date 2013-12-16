using Microsoft.Web.WebPages.OAuth;
using VK.Code;

namespace VK.App_Start
{
    public static class AuthConfig
    {
        public static void RegisterAuth()
        {
            // To let users of this site log in using their accounts from other sites such as Microsoft, Facebook, and Twitter,
            // you must update this site. For more information visit http://go.microsoft.com/fwlink/?LinkID=252166

            //OAuthWebSecurity.RegisterMicrosoftClient(
            //    clientId: "",
            //    clientSecret: "");

            //OAuthWebSecurity.RegisterTwitterClient(
            //    consumerKey: "",
            //    consumerSecret: "");

            OAuthWebSecurity.RegisterFacebookClient(
                "261197307362913",
                "a4b1a49ac079eec14d98ad0769bc1fc1");

            OAuthWebSecurity.RegisterGoogleClient();

            OAuthWebSecurity.RegisterClient(new VKontakteAuthenticationClient("4033767", "F6MUVJnPEAtNAi58nIcl"), "ВКонтакте", null);
        }
    }
}
