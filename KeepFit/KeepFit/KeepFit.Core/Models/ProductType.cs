using System.Collections.Generic;

namespace KeepFit.Core.Models
{
    public class ProductType:AuditableEntity
    {
        public ProductType()
        {
            Products = new List<Product>();
        }
        public override int Id
        {
            get { return ProductTypeId; }
        }
        public int ProductTypeId { get; set; }

        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; } 
    }
}
