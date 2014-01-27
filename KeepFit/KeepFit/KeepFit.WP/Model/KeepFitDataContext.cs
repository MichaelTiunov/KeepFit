using System.Data.Linq;

namespace KeepFit.WP.Model
{
    public class KeepFitDataContext : DataContext
    {
        public KeepFitDataContext(string connectionString)
            : base(connectionString)
        { }
        // Specify a table for the to-do items.
        public Table<Excercise> Excercises;

        // Specify a table for the categories.
        public Table<ExcerciseCategory> ExcercisesCategories;

        public Table<Workout> Workouts;
    }
}
