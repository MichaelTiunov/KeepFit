using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepFit.Core.Dto
{
    public class BodyCompositionDto
    {
        [Display(Name = "Вес")]
        public double Weight { get; set; }
        public double Height { get; set; }
    }
}
