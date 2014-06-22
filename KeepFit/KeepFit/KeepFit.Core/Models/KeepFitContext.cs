using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Configuration = KeepFit.Core.Migrations.Configuration;

namespace KeepFit.Core.Models
{
    public partial class KeepFitContext : ExtendedContext, IKeepFitContext
    {
        static KeepFitContext()
        {
            Database.SetInitializer<KeepFitContext>(null);
            //Database.SetInitializer<DaikinContext>(new DropCreateDatabaseIfModelChanges<DaikinContext>());
            //Database.SetInitializer<DaikinContext>(new CreateDatabaseIfNotExists<DaikinContext>());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<KeepFitContext, Configuration>());
        }

        //TODO: REMOVEME
        public KeepFitContext()
            : base(ConnectionStringManager.ConnectionString, null)
        {
            Database.Initialize(false);
        }

        public KeepFitContext(IIdentityAuditProvider identityAuditProvider)
            : base(ConnectionStringManager.ConnectionString, identityAuditProvider)
        {
            Database.Initialize(false);
        }

       
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.Configuration.LazyLoadingEnabled = false;

           

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();            
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<IndividualRole> IndividualRoles { get; set; }
        public DbSet<Individual> Individuals { get; set; }
        public DbSet<PasswordChange> PasswordChanges { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<BodyComposition> BodyCompositions { get; set; }
        public DbSet<ProgressPhoto> ProgressPhotos { get; set; }
        public DbSet<Excercise> Excercises { get; set; }
        public DbSet<ExcerciseCategory> ExcerciseCategories { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<Set> Sets { get; set; }
        public DbSet<Reps> Repses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Ingestion> Ingestions { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Picture> Pictures { get; set; }
    }
}