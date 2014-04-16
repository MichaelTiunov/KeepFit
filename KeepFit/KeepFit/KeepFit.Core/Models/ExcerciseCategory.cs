using System;
using System.Collections.Generic;

namespace KeepFit.Core.Models
{
    public class ExcerciseCategory : AuditableEntity
    {
        public ExcerciseCategory()
        {
            Excercises = new List<Excercise>();
        }
        public override int Id
        {
            get { return ExcerciseCategoryId; }
        }
        public int ExcerciseCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Excercise> Excercises { get; set; }
    }
}
