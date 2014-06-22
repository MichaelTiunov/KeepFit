using System.Data.Entity.Migrations;
using KeepFit.Core.Models;

namespace KeepFit.Core.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<KeepFitContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(KeepFitContext context)
        {

        }
    }
}
