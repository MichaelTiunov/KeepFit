using System.Collections.Generic;
using KeepFit.Core.Models;

namespace KeepFit.Core.Services
{
    public interface IExcerciseService
    {
        IEnumerable<ExcerciseCategory> GetCategories();

        void SaveCategory(ExcerciseCategory category);
        IEnumerable<Excercise> GetExcercises(int categoryId);

        IEnumerable<Excercise> GetExcercises();

        void SaveExcercise(Excercise excercise);
    }
}
