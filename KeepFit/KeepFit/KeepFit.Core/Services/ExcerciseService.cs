using System.Collections.Generic;
using System.Linq;
using KeepFit.Core.Models;

namespace KeepFit.Core.Services
{
    public class ExcerciseService : IExcerciseService
    {
        private readonly IKeepFitContext keepFitContext;
        public ExcerciseService(IKeepFitContext keepFitContext)
        {
            this.keepFitContext = keepFitContext;
        }
        public IEnumerable<ExcerciseCategory> GetCategories()
        {
            return keepFitContext.ExcerciseCategories;
        }

        public void SaveCategory(ExcerciseCategory category)
        {
            keepFitContext.ExcerciseCategories.Add(category);
            keepFitContext.SaveChanges();
        }

        public IEnumerable<Excercise> GetExcercises(int categoryId)
        {
            return keepFitContext.Excercises.Where(x => x.ExcerciseCategoryId == categoryId);
        }

        public IEnumerable<Excercise> GetExcercises()
        {
            return keepFitContext.Excercises;
        }

        public void SaveExcercise(Excercise excercise)
        {
            keepFitContext.Excercises.Add(excercise);
            keepFitContext.SaveChanges();
        }
    }
}
