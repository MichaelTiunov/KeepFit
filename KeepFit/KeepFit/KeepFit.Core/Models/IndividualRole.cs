using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepFit.Core.Models
{
    public partial class IndividualRole : AuditableEntity
    {
        public int IndividualRoleId { get; set; }

        public int RoleId { get; set; }

        public int IndividualId { get; set; }

        public bool IsCurrentSelected { get; set; }

        public virtual Individual Individual { get; set; }

        public virtual Role Role { get; set; }

        public override int Id
        {
            get { return IndividualRoleId; }
        }
    }
}
