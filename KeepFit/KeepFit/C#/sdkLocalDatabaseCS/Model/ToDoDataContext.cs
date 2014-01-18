/* 
    Copyright (c) 2011 Microsoft Corporation.  All rights reserved.
    Use of this sample source code is subject to the terms of the Microsoft license 
    agreement under which you licensed this sample source code and is provided AS-IS.
    If you did not accept the terms of the license agreement, you are not authorized 
    to use this sample source code.  For the terms of the license, please see the 
    license agreement between you and Microsoft.
  
    To see all Code Samples for Windows Phone, visit http://go.microsoft.com/fwlink/?LinkID=219604 
  
*/
using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace LocalDatabaseSample.Model
{

    public class ToDoDataContext : DataContext
    {
        // Pass the connection string to the base class.
        public ToDoDataContext(string connectionString)
            : base(connectionString)
        { }

        // Specify a table for the to-do items.
        public Table<Excercise> Items;

        // Specify a table for the categories.
        public Table<ExcerciseCategory> Categories;
    }
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


        // Internal column for the associated ExcerciseCategory ID value
        [Column]
        internal int categoryId;

        // Entity reference, to identify the ExcerciseCategory "storage" table
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
