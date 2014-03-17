using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepFit.Core.Models
{
    public partial class Address : AuditableEntity
    {
        public Address()
        {
            Individuals = new List<Individual>();
        }

        public int AddressId { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public int? CountryId { get; set; }

        public string City { get; set; }

        public int? StateId { get; set; }

        public string Zip { get; set; }

        public virtual Country Country { get; set; }

        public virtual State State { get; set; }

        public virtual ICollection<Individual> Individuals { get; set; }


        public override int Id
        {
            get { return AddressId; }
        }
    }
}
