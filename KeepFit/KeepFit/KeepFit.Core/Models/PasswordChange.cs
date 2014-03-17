using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepFit.Core.Models
{
    public partial class PasswordChange : AuditableEntity
    {
        public int PasswordChangeId { get; set; }
        public int UserId { get; set; }
        public string NewPassword { get; set; }
        public string PasswordSalt { get; set; }
        public DateTime ChangeDateTime { get; set; }
        public bool ForseReseted { get; set; }
        public virtual User User { get; set; }

        public override int Id
        {
            get { return PasswordChangeId; }
        }
    }
}
