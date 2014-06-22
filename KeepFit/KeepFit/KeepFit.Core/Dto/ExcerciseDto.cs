using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using KeepFit.Core.Models;

namespace KeepFit.Core.Dto
{
    public class ExcerciseDto
    {
        public int ExcerciseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ExcerciseCategoryId { get; set; }

        [Display(Name = "Фото")]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase ExcercisePhoto { get; set; }

        public IEnumerable<ExcerciseCategory> ExcerciseCategories { get; set; }
    }
}

