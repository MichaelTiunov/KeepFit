using System.Data.Entity.ModelConfiguration;

namespace KeepFit.Core.Models.Mapping
{
    public class SetMap : EntityTypeConfiguration<Set>
    {
        public SetMap()
        {
            Property(t => t.SetId)
                .IsRequired();

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

            HasRequired(t => t.Workout)
                .WithMany(t => t.Sets)
                .HasForeignKey(d => d.WorkoutId);
        }
    }
}
