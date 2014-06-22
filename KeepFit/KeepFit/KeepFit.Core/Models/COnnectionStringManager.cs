using System.Configuration;

namespace KeepFit.Core.Models
{
    public static class ConnectionStringManager
    {
        private const string ConnectionStringName = "KeepFitContext";

        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString;
            }
        }
    }
}
