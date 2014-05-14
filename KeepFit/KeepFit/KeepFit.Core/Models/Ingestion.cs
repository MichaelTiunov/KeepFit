using System.Collections.Generic;

namespace KeepFit.Core.Models
{
    public class Ingestion:AuditableEntity
    {
        public Ingestion()
        {
            Products = new List<Product>();
        }
        public override int Id
        {
            get { return IngestionId; }
        }

        public int IngestionId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; } 
    }
}
