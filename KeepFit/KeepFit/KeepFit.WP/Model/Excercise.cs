using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace KeepFit.WP.Model
{
    [Table]
    public class Excercise : INotifyPropertyChanged, INotifyPropertyChanging
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangingEventHandler PropertyChanging;

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

        private int excerciseId;
        private string excerciseName;

        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int ExcerciseId
        {
            get { return excerciseId; }
            set
            {
                if (excerciseId != value)
                {
                    NotifyPropertyChanging("ExcerciseId");
                    excerciseId = value;
                    NotifyPropertyChanged("ExcerciseId");
                }
            }
        }

        [Column]
        public string ExcerciseName
        {
            get { return excerciseName; }
            set
            {
                if (excerciseName != value)
                {
                    NotifyPropertyChanging("ExcerciseName");
                    excerciseName = value;
                    NotifyPropertyChanged("ExcerciseName");
                }
            }
        }

        // Version column aids update performance.
        [Column(IsVersion = true)]
        private Binary version;


        // Internal column for the associated ToDoCategory ID value
        [Column]
        internal int categoryId;

        // Entity reference, to identify the ToDoCategory "storage" table
        private EntityRef<ExcerciseCategory> excerciseCategory;

        // Association, to describe the relationship between this key and that "storage" table
        [Association(Storage = "category", ThisKey = "categoryId", OtherKey = "Id", IsForeignKey = true)]
        public ExcerciseCategory Category
        {
            get { return excerciseCategory.Entity; }
            set
            {
                NotifyPropertyChanging("Category");
                excerciseCategory.Entity = value;

                if (value != null)
                {
                    categoryId = value.Id;
                }

                NotifyPropertyChanging("Category");
            }
        }
    }
}
