using System;

namespace KeepFit.Core.Models
{
    public class Excercise : AuditableEntity
    {
        public override int Id
        {
            get { return ExcerciseId; }
        }
        public int ExcerciseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ExcerciseCategoryId { get; set; }
        public ExcerciseCategory ExcerciseCategory { get; set; }
    }
}
