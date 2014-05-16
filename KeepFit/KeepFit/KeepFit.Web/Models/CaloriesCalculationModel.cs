using System.ComponentModel.DataAnnotations;
using KeepFit.Web.Resources;

namespace KeepFit.Web.Models
{
    public class CaloriesCalculationModel
    {
        [Display(ResourceType = typeof(Calculation), Name = "Gender")]
        public Gender Gender { get; set; }
        [Display(ResourceType = typeof (Calculation), Name = "ActivityType")]
        public ActivityType ActivityType { get; set; }
        [Display(ResourceType = typeof(Calculation), Name = "Age")]
        public int Age { get; set; }
        [Display(ResourceType = typeof(Calculation), Name = "Height")]
        public double Height { get; set; }
        [Display(ResourceType = typeof(Calculation), Name = "Weight")]
        public double Weight { get; set; }
    }

    public enum Gender
    {
        Male = 0,
        Female = 1
    }

    public enum ActivityType
    {
        [Display(Name = "Минимальный")]
        Minimum = 0,
        [Display(Name = "Низкий")]
        Low = 1,
        [Display(Name = "Средний")]
        Middle = 2,
        [Display(Name = "Высокий")]
        Hight = 3,
        [Display(Name = "Очень высокий")]
        VeryHight = 4
    }
}