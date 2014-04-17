using System.Collections.Generic;
using KeepFit.Core.Dto;
using KeepFit.Core.Models;

namespace KeepFit.Core.Services
{
    public interface IWorkoutService
    {
        IEnumerable<Workout> GetWorkouts(int userId);
        IEnumerable<Workout> GetWorkouts(bool isPublic = true);
        void AddWorkout(WorkoutDto workout);
    }
}
