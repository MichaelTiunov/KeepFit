using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace KeepFit.Core.Models
{
    public class User : AuditableEntity
    {
        public User()
        {
            PasswordChanges = new List<PasswordChange>();
            BodyCompositions = new List<BodyComposition>();
            ProgressPhotos = new Collection<ProgressPhoto>();
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

        public virtual ICollection<BodyComposition> BodyCompositions { get; set; }

        public virtual ICollection<ProgressPhoto> ProgressPhotos { get; set; }
    }
}
