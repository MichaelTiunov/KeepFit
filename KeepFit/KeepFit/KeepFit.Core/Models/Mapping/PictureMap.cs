using System.Data.Entity.ModelConfiguration;

namespace KeepFit.Core.Models.Mapping
{
    public class PictureMap : EntityTypeConfiguration<Picture>
    {
        public PictureMap()
        {
            Property(t => t.PictureId)
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

            HasOptional(t => t.Product)
                .WithMany(t => t.Pictures)
                .HasForeignKey(d => d.ProductId);

            HasOptional(t => t.Excercise)
              .WithMany(t => t.Pictures)
              .HasForeignKey(d => d.ExcerciseId);
        }
    }
}
