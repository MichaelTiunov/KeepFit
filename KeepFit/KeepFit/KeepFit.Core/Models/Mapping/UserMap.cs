using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepFit.Core.Models.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            this.HasKey(t => t.UserId);
            
            this.Property(t => t.IndividualId).IsRequired();

            this.Property(t => t.IsActive)
                .IsRequired();

            this.Property(t => t.IsDeleted)
                .IsRequired();

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

            // Properties
            this.Property(t => t.Username)
                .IsRequired()
                .HasMaxLength(200);

            // Relationships
            this.HasRequired(t => t.Individual)
                .WithOptional(i => i.User);


        }
    }
}
