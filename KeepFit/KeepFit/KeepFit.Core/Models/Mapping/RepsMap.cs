using System.Data.Entity.ModelConfiguration;

namespace KeepFit.Core.Models.Mapping
{
    public class RepsMap : EntityTypeConfiguration<Reps>
    {
        public RepsMap()
        {
            Property(t => t.SetId)
                .IsRequired();


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

            HasRequired(t => t.Set)
                .WithMany(t => t.Repses)
                .HasForeignKey(d => d.SetId);

            HasRequired(x => x.Excercise)
                .WithMany(x => x.Repses)
                .HasForeignKey(x => x.ExcerciseId);
        }
    }
}