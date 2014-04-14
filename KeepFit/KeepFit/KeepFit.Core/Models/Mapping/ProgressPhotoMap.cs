using System.Data.Entity.ModelConfiguration;

namespace KeepFit.Core.Models.Mapping
{
    public class ProgressPhotoMap : EntityTypeConfiguration<ProgressPhoto>
    {
        public ProgressPhotoMap()
        {
            Property(t => t.ProgressPhotoId)
                .IsRequired();

            Property(t => t.Photo);
            
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
                .WithMany(t => t.ProgressPhotos)
                .HasForeignKey(d => d.UserId);
        }
    }
}
