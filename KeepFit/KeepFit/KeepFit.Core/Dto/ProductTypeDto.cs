using System.ComponentModel.DataAnnotations;

namespace KeepFit.Core.Dto
{
    public class ProductTypeDto
    {
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }
    }
}
