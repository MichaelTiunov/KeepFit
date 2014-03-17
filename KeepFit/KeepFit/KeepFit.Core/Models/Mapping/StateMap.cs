using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepFit.Core.Models.Mapping
{
    public class StateMap : EntityTypeConfiguration<State>
    {
        public StateMap()
        {
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(200);

            this.HasRequired(t => t.Country)
                .WithMany(t => t.States)
                .HasForeignKey(d => d.CountryId);


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
        }
    }
}
