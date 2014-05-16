using System.Data.Entity.ModelConfiguration;

namespace KeepFit.Core.Models.Mapping
{
    public class ProductTypeMap : EntityTypeConfiguration<ProductType>
    {
        public ProductTypeMap()
        {
            HasKey(x => x.ProductTypeId);
            Property(x => x.Name);
        }
    }
}
