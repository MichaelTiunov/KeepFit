using System.Data.Entity.ModelConfiguration;

namespace KeepFit.Core.Models.Mapping
{
    public class IngestionMap : EntityTypeConfiguration<Ingestion>
    {
        public IngestionMap()
        {
            HasKey(x => x.IngestionId);
            Property(x => x.Name);

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
