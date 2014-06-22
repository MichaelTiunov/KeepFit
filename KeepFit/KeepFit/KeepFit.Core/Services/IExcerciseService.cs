using System.Collections.Generic;
using KeepFit.Core.Dto;
using KeepFit.Core.Models;

namespace KeepFit.Core.Services
{
    public interface IExcerciseService
    {
        IEnumerable<ExcerciseCategory> GetCategories();

        void AddOrUpdateExcerciseCategory(ExcerciseCategoryDto category);

        void AddOrUpdateExcercise(ExcerciseDto category);
        IEnumerable<Excercise> GetExcercises(int categoryId);

        IEnumerable<Excercise> GetExcercises();

        ExcerciseDto GetExcercise(int excerciseId);
        void SaveExcercise(Excercise excercise);
    }
}
