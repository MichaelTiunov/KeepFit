using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace KeepFit.Core.Models
{
    public partial class Individual : AuditableEntity
    {
        public Individual()
        {
            this.IndividualRoles = new List<IndividualRole>();
            this.Sites = new List<Site>();
        }

        public int IndividualId { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string CellPhoneNumber { get; set; }

        public string WorkPhoneNumber { get; set; }

        public int? AddressId { get; set; }

        public int? OrganizationId { get; set; }

        public string EmailAddress { get; set; }

        public virtual Address Address { get; set; }

        public virtual ICollection<IndividualRole> IndividualRoles { get; set; }

        public virtual ICollection<Site> Sites { get; set; }

        public virtual User User { get; set; }

        public override int Id
        {
            get { return IndividualId; }
        }
    }
}
