using System.Collections.Generic;
using KeepFit.Core.Models;

namespace KeepFit.Web.Models
{
    public class ExcercisesModel
    {
        public IEnumerable<Excercise> Excercises { get; set; } 
        public IEnumerable<ExcerciseCategory> ExcerciseCategories { get; set; }
    }
}