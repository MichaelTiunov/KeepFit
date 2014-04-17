using System;
using System.Collections.Generic;

namespace KeepFit.Core.Models
{
    public class Excercise : AuditableEntity
    {
        public Excercise()
        {
            Repses = new List<Reps>();
        }
        public override int Id
        {
            get { return ExcerciseId; }
        }
        public int ExcerciseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ExcerciseCategoryId { get; set; }
        public ExcerciseCategory ExcerciseCategory { get; set; }

        public virtual ICollection<Reps> Repses { get; set; } 
    }
}
