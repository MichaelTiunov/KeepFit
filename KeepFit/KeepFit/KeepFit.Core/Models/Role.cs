using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepFit.Core.Models
{
    public partial class Role : AuditableEntity
    {
        public Role()
        {
            this.IndividualRoles = new List<IndividualRole>();
        }

        public int RoleId { get; set; }

        public string RoleName { get; set; }

        public virtual ICollection<IndividualRole> IndividualRoles { get; set; }

        public override int Id
        {
            get { return RoleId; }
        }
    }
}
