using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepFit.Core.Models.Mapping
{
    public class IndividualRoleMap : EntityTypeConfiguration<IndividualRole>
    {
        public IndividualRoleMap()
        {
            this.Property(t => t.CreatedBy)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.CreatedDate)
                .IsRequired();
            this.Property(t => t.IsCurrentSelected).IsRequired();

            this.Property(t => t.UpdatedBy)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.UpdatedDate)
                .IsRequired();

            // Relationships
            this.HasRequired(t => t.Individual)
                .WithMany(t => t.IndividualRoles)
                .HasForeignKey(d => d.IndividualId);
            this.HasRequired(t => t.Role)
                .WithMany(t => t.IndividualRoles)
                .HasForeignKey(d => d.RoleId);

        }
    }
}
