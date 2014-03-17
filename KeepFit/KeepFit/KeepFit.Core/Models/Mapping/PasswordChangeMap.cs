using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepFit.Core.Models.Mapping
{
    public class PasswordChangeMap : EntityTypeConfiguration<PasswordChange>
    {
        public PasswordChangeMap()
        {
            // Properties
            this.Property(t => t.NewPassword)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.CreatedBy)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.CreatedDate)
                .IsRequired();

            this.Property(t => t.ForseReseted)
                .IsRequired();

            this.Property(t => t.UpdatedBy)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.UpdatedDate)
                .IsRequired();

            // Relationships
            this.HasRequired(t => t.User)
                .WithMany(t => t.PasswordChanges)
                .HasForeignKey(d => d.UserId);
        }
    }
}
