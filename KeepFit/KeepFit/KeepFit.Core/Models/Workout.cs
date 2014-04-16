using System;

namespace KeepFit.Core.Models
{
    public class Workout : AuditableEntity
    {
        public override int Id
        {
            get { return WorkoutId; }
        }

        public int WorkoutId { get; set; }

        public DateTime WorkoutDate { get; set; }

        public string Name { get; set; }

        public bool IsPublic { get; set; }
        public double Duration { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
}
}
