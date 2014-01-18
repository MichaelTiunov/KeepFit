using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace KeepFit.WP.Model
{
    [Table]
    public class ExcerciseCategory : INotifyPropertyChanged, INotifyPropertyChanging
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


        private int id;
        private string name;

        [Column(DbType = "INT NOT NULL IDENTITY", IsDbGenerated = true, IsPrimaryKey = true)]
        public int Id
        {
            get { return id; }
            set
            {
                NotifyPropertyChanging("Id");
                id = value;
                NotifyPropertyChanged("Id");
            }
        }

        [Column]
        public string Name
        {
            get { return name; }
            set
            {
                NotifyPropertyChanging("Name");
                name = value;
                NotifyPropertyChanged("Name");
            }
        }

        [Column(IsVersion = true)]
        private Binary version;

        // Define the entity set for the collection side of the relationship.
        private EntitySet<Excercise> excercises;

        [Association(Storage = "excercises", OtherKey = "categoryId", ThisKey = "Id")]
        public EntitySet<Excercise> Excercises
        {
            get { return excercises; }
            set { excercises.Assign(value); }
        }

        // Assign handlers for the add and remove operations, respectively.
        public ExcerciseCategory()
        {
            excercises = new EntitySet<Excercise>(
                AttachExcercise,
                DetachExcercise
                );
        }
        // Called during an add operation
        private void AttachExcercise(Excercise excercise)
        {
            NotifyPropertyChanging("Excercise");
            excercise.Category = this;
        }

        // Called during a remove operation
        private void DetachExcercise(Excercise excercise)
        {
            NotifyPropertyChanging("Excercise");
            excercise.Category = null;
        }
    }
}
