using System.ComponentModel.DataAnnotations;

namespace KeepFit.Web.Models
{
    public class UserModel : Web.Models.BodyStatistic
    {
        [Display(Name = "Пол")]
        public Gender UserGender { get; set; }
        [Display(Name = "Возраст")]
        public int Age { get; set; }

        public double PercentageOfBodyFat { get; set; }

        public double BaseMetabolicSpeed
        {
            get;
            set;
        }

        public void CalculateBaseMetabolicSpeed()
        {
            if (UserGender == Gender.Male)
            {
                BaseMetabolicSpeed = 66 + (13.7 * Weight) + (5 * Growth) - (6.8 * Age);
            }
            else
            {
                BaseMetabolicSpeed = 65.5 + (9.6 * Weight) + (1.8 * Growth) - (4.7 * Age);
            }
        }

        public void CalculatePercentageOfBodyFat()
        {
            var genderConstant = UserGender == Gender.Male ? Weight - 98.42 : Weight - 76.76;
            PercentageOfBodyFat = (4.15 * Waistline - 0.082 * genderConstant) / Weight;
        }

    }
    public enum Gender
    {
        Male,
        Female
    }
}