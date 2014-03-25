using System;

namespace KeepFit.Core.Models
{
    public class BodyComposition : AuditableEntity
    {
        public override int Id
        {
            get { throw new NotImplementedException(); }
        }

        public int BodyCompositionId { get; set; }

        public double Height { get; set; }
        public double Weight { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
