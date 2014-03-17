using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepFit.Core.Models.Mapping
{
    public class AddressMap : EntityTypeConfiguration<Address>
    {
        public AddressMap()
        {
            this.Property(t => t.AddressLine1)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.AddressLine2)
                .HasMaxLength(200);

            this.Property(t => t.City)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.Zip)
                .IsRequired()
                .HasMaxLength(10);

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

            this.HasOptional(t => t.Country)
                .WithMany(t => t.Addresses)
                .HasForeignKey(d => d.CountryId);

            this.HasOptional(t => t.State)
                .WithMany(t => t.Addresses)
                .HasForeignKey(d => d.StateId);
        }
    }
}
