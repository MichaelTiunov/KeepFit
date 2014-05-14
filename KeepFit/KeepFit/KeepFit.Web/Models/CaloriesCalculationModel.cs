namespace KeepFit.Web.Models
{
    public class CaloriesCalculationModel
    {
        public Gender Gender { get; set; }
        public ActivityType ActivityType { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
    }

    public enum Gender
    {
        Male = 0,
        Female = 1
    }

    public enum ActivityType
    {
        Minimum = 0,
        Low = 1,
        Middle = 2,
        Hight = 3,
        VeryHight = 4
    }
}