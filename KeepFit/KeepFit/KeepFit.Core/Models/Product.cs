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

    }
}
