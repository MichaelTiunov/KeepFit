using System.Data.Entity.ModelConfiguration;

namespace KeepFit.Core.Models.Mapping
{
    public class ExcerciseMap : EntityTypeConfiguration<Excercise>
    {
        public ExcerciseMap()
        {
            Property(t => t.ExcerciseId)
                .IsRequired();

            Property(t => t.Name);
            Property(t => t.Description);

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

            HasRequired(t => t.ExcerciseCategory)
                .WithMany(t => t.Excercises)
                .HasForeignKey(d => d.ExcerciseCategoryId);
        }
    }
}
