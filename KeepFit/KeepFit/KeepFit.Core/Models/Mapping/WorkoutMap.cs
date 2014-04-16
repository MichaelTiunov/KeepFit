using System.Data.Entity.ModelConfiguration;

namespace KeepFit.Core.Models.Mapping
{
    public class WorkoutMap : EntityTypeConfiguration<Workout>
    {
        public WorkoutMap()
        {
            Property(t => t.WorkoutId)
                .IsRequired();

            Property(t => t.Name);
            Property(t => t.WorkoutDate);
            Property(t => t.IsPublic);
            Property(t => t.Duration);

            Property(t => t.CreatedBy)
                .IsRequired()
                .HasMaxLength(200);

            Property(t => t.CreatedDate)
                .IsRequired();

            Property(t => t.UpdatedBy)
                .IsRequired()
                .HasMaxLength(200);

            Property(t => t.UpdatedDate)
                .IsRequired();

            HasRequired(t => t.User)
                .WithMany(t => t.Workouts)
                .HasForeignKey(d => d.UserId);
        }
    }
}
