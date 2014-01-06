using KeepFit.Web.Code;
using Microsoft.Web.WebPages.OAuth;

namespace KeepFit.Web
{
    public static class AuthConfig
    {
        public static void RegisterAuth()
        {

            OAuthWebSecurity.RegisterFacebookClient(
                "261197307362913",
                "a4b1a49ac079eec14d98ad0769bc1fc1");

            OAuthWebSecurity.RegisterGoogleClient();

            OAuthWebSecurity.RegisterClient(new VKontakteAuthenticationClient("4033767", "F6MUVJnPEAtNAi58nIcl"), "ВКонтакте", null);
        }
    }
}
