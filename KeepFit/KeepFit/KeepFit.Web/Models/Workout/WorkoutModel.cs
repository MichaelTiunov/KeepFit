using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KeepFit.Web.Models.Workout
{
    public class WorkoutModel
    {
        public IEnumerable<Core.Models.Workout> Workouts { get; set; }
    }
}