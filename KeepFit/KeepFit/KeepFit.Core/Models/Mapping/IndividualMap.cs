using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepFit.Core.Models.Mapping
{
    public class IndividualMap : EntityTypeConfiguration<Individual>
    {
        public IndividualMap()
        {
            HasKey(x => x.IndividualId);
            // Properties
            this.Property(t => t.FirstName)
                .HasMaxLength(200);

            this.Property(t => t.MiddleName)
                .IsOptional()
                .HasMaxLength(200);

            this.Property(t => t.LastName)
                .HasMaxLength(200);

            this.Property(t => t.EmailAddress)
                .IsOptional()
                .HasMaxLength(200);

            this.Property(t => t.CreatedBy)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.CreatedDate)
                .IsRequired();

            this.Property(t => t.UpdatedBy)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.UpdatedDate)
                .IsRequired();


            this.HasOptional(t => t.Address)
                .WithMany(t => t.Individuals);
        }
    }
}
