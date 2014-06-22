using System;
using System.Collections.Generic;
using System.Linq;
using KeepFit.Core.Dto;
using KeepFit.Core.Models;

namespace KeepFit.Core.Services
{
    public class WorkoutService : IWorkoutService
    {
        private readonly IKeepFitContext keepFitContext;

        public WorkoutService(IKeepFitContext keepFitContext)
        {
            this.keepFitContext = keepFitContext;
        }
        public IEnumerable<Workout> GetWorkouts(int userId)
        {
            return keepFitContext.Workouts.Where(x => x.UserId == userId);
        }

        public IEnumerable<Workout> GetWorkouts(bool isPublic = true)
        {
            return keepFitContext.Workouts.Where(x => x.IsPublic == isPublic);
        }

        public void AddWorkout(WorkoutDto workout)
        {
            var work = new Workout
            {
                Name = workout.Name,
                WorkoutDate = workout.WorkoutDate,
                UserId = workout.UserId
            };
            keepFitContext.Workouts.Add(work);
            keepFitContext.SaveChanges();
        }
    }
}
