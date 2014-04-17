using System.Collections.Generic;
using KeepFit.Core.Dto;

namespace KeepFit.Web.Models.Workout
{
    public class WorkoutModel
    {
        public IEnumerable<Core.Models.Workout> Workouts { get; set; }

        public WorkoutDto Workout { get; set; }
    }
}