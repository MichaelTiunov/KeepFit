using System.Collections.Generic;

namespace KeepFit.Core.Models
{
    public class Product : AuditableEntity
    {
        public override int Id
        {
            get { return ProductId; }
        }

        public int ProductId { get; set; }

        public string Name { get; set; }

        public double CaloricValue { get; set; }
        public double Proteins { get; set; }
        public double Fats { get; set; }
        public double Carbohydrates { get; set; }

        public int ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }
        public virtual ICollection<Ingestion> Ingestions { get; set; }

        public virtual ICollection<Picture> Pictures { get; set; }

        public string ProductPhoto { get; set; }

    }
}
