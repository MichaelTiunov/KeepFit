﻿using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace KeepFit.WP.Model
{
    [Table]
    public class Workout : INotifyPropertyChanged, INotifyPropertyChanging
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangingEventHandler PropertyChanging;

        private int id;
        private DateTime workoutDateTime;
        private string workoutName;

        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int Id
        {
            get { return id; }
            set
            {
                if (id != value)
                {
                    NotifyPropertyChanging("Id");
                    id = value;
                    NotifyPropertyChanged("Id");
                }
            }
        }

        [Column]
        public DateTime WorkoutDateTime
        {
            get { return workoutDateTime; }
            set
            {
                if (workoutDateTime != value)
                {
                    NotifyPropertyChanging("WorkoutDateTime");
                    workoutDateTime = value;
                    NotifyPropertyChanged("WorkoutDateTime");
                }
            }
        }

        [Column]
        public string WorkoutName
        {
            get
            {
                return workoutName; 
            }
            set
            {
                if (workoutName != value)
                {
                    NotifyPropertyChanging("WorkoutName");
                    workoutName = value;
                    NotifyPropertyChanged("WorkoutName");
                }
            }
        }

        [Column(IsVersion = true)]
        private Binary version;

        // Define the entity set for the collection side of the relationship.
        private EntitySet<Sets> sets;

        [Association(Storage = "sets", OtherKey = "WorkoutId", ThisKey = "Id")]
        public EntitySet<Sets> ToDos
        {
            get { return this.sets; }
            set { this.sets.Assign(value); }
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