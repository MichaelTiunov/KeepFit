using System.Data.Entity.ModelConfiguration;

namespace KeepFit.Core.Models.Mapping
{
    public class BodyCompositionMap : EntityTypeConfiguration<BodyComposition>
    {
        public BodyCompositionMap()
        {
            Property(t => t.BodyCompositionId)
                .IsRequired();

            Property(t => t.Height);
            Property(t => t.Weight);
            
            
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
                .WithMany(t => t.BodyCompositions)
                .HasForeignKey(d => d.UserId);
        }
    }
}
