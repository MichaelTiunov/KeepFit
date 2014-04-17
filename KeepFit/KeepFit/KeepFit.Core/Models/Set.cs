

using System.Collections.Generic;

namespace KeepFit.Core.Models
{
    public class Set : AuditableEntity
    {
        public Set()
        {
            Repses = new List<Reps>();
        }
        public override int Id
        {
            get { return SetId; }
        }
        public int SetId { get; set; }

        public int WorkoutId { get; set; }

        public Workout Workout { get; set; }

        public virtual ICollection<Reps> Repses { get; set; } 
    }
}
