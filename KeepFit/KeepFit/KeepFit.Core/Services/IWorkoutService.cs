using System.Collections.Generic;
using KeepFit.Core.Models;

namespace KeepFit.Core.Services
{
    public interface IWorkoutService
    {
        IEnumerable<Workout> GetWorkouts(int userId);
        IEnumerable<Workout> GetWorkouts(bool isPublic = true);
        void AddWorkout(Workout workout);
    }
}
