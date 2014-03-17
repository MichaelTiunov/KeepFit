using System.Data.Entity;

namespace KeepFit.Core.Models
{
    public interface IKeepFitContext
    {
        DbSet<Blog> Blogs { get; set; }
        DbSet<Post> Posts { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Role> Roles { get; set; }

        DbSet<Address> Addresses { get; set; }
        DbSet<IndividualRole> IndividualRoles { get; set; }
        DbSet<Individual> Individuals { get; set; }
        DbSet<PasswordChange> PasswordChanges { get; set; }
        DbSet<State> States { get; set; }
        DbSet<Country> Countries { get; set; }
    }
}
