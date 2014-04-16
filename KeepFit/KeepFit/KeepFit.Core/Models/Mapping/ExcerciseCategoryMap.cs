using System.Data.Entity.ModelConfiguration;

namespace KeepFit.Core.Models.Mapping
{
    public class ExcerciseCategoryMap : EntityTypeConfiguration<ExcerciseCategory>
    {
        public ExcerciseCategoryMap()
        {
            Property(t => t.ExcerciseCategoryId)
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
        }
    }
}
