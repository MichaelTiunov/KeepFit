using System.Data.Entity.ModelConfiguration;

namespace KeepFit.Core.Models.Mapping
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            HasKey(x => x.ProductId);
            Property(x => x.CaloricValue);
            Property(x => x.Proteins);
            Property(x => x.Carbohydrates);
            Property(x => x.Fats);
        }
    }
}
