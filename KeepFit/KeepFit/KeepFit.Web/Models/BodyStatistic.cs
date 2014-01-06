using System.ComponentModel.DataAnnotations;

namespace KeepFit.Web.Models
{
    public class BodyStatistic
    {
        [Display(Name = "Вес")]
        public double Weight { get; set; }
        [Display(Name = "Рост")]
        public double Growth { get; set; }
        [Display(Name = "Обхват талии")]
        public double Waistline { get; set; }
        [Display(Name = "Обхват груди")]
        public double Chest { get; set; }
        [Display(Name = "Обхват шеи")]
        public double Neck { get; set; }
        [Display(Name = "Обхват плеч")]
        public double Shoulders { get; set; }
        [Display(Name = "Обхват предплечья")]
        public double Forearms { get; set; }
        [Display(Name = "Обхват голени")]
        public double Calves { get; set; }
        [Display(Name = "Обхват бёдер")]
        public double Thighs { get; set; }
    }
}