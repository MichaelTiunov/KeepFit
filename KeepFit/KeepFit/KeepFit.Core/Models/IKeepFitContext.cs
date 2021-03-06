﻿using System.Data.Entity;

namespace KeepFit.Core.Models
{
    public interface IKeepFitContext : IDatabaseContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Role> Roles { get; set; }

        DbSet<Address> Addresses { get; set; }
        DbSet<IndividualRole> IndividualRoles { get; set; }
        DbSet<Individual> Individuals { get; set; }
        DbSet<PasswordChange> PasswordChanges { get; set; }
        DbSet<State> States { get; set; }
        DbSet<BodyComposition> BodyCompositions { get; set; }
        DbSet<ProgressPhoto> ProgressPhotos { get; set; }
        DbSet<Excercise> Excercises { get; set; }
        DbSet<ExcerciseCategory> ExcerciseCategories { get; set; }
        DbSet<Workout> Workouts { get; set; }
        DbSet<Set> Sets { get; set; }
        DbSet<Reps> Repses { get; set; }

        DbSet<Product> Products { get; set; }

        DbSet<Menu> Menus { get; set; }
        DbSet<Ingestion> Ingestions { get; set; }

        DbSet<ProductType> ProductTypes { get; set; }

        DbSet<Picture> Pictures { get; set; }
    }
}
