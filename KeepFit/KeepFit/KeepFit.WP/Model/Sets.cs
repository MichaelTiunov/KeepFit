using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace KeepFit.WP.Model
{
    [Table]
    public class Sets: INotifyPropertyChanged, INotifyPropertyChanging
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangingEventHandler PropertyChanging;

        private int setsId;

        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int SetsId
        {
            get
            {
                return setsId; 
            }
            set
            {
                if (setsId != value)
                {
                    NotifyPropertyChanging("SetsId");
                    setsId = value;
                    NotifyPropertyChanged("SetsId");
                }
            }
        }

        [Column(IsVersion = true)]
        private Binary version;

        // Internal column for the associated ToDoCategory ID value
        [Column]
        internal int WorkoutId;

        // Entity reference, to identify the ToDoCategory "storage" table
        private EntityRef<Workout> workout;

        // Association, to describe the relationship between this key and that "storage" table
        [Association(Storage = "workout", ThisKey = "SetsId", OtherKey = "Id", IsForeignKey = true)]
        public Workout Workout
        {
            get { return workout.Entity; }
            set
            {
                NotifyPropertyChanging("Workout");
                workout.Entity = value;

                if (value != null)
                {
                    WorkoutId = value.Id;
                }

                NotifyPropertyChanging("Workout");
            }
        }
        

        private void NotifyPropertyChanging(string propertyName)
        {
            if (PropertyChanging != null)
            {
                PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
            }
        }
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


    }
}
