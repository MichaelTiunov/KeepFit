using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KeepFit.Core.Models
{
    public partial class User : AuditableEntity
    {
        public User()
        {
        }

        public int UserId { get; set; }
        public string Username { get; set; }

        public int IndividualId { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        [Required]
        public virtual Individual Individual { get; set; }

        public override int Id
        {
            get { return IndividualId; }
        }

        public virtual ICollection<PasswordChange> PasswordChanges { get; set; }
    }
}
