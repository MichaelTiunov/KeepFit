using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace KeepFit.Core.Models
{
    public class Country : AuditableEntity
    {
        public int CountryId { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "alpha-2")]
        public string ShortName { get; set; }

        public virtual ICollection<State> States { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }

        public override int Id
        {
            get { return CountryId; }
        }
    }
}
