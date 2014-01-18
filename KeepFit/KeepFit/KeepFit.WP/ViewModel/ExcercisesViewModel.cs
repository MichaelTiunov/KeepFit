﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using KeepFit.WP.Model;

namespace KeepFit.WP.ViewModel
{
    public class ExcercisesViewModel : INotifyPropertyChanged
    {
        private readonly KeepFitDataContext keepFitContext;


        public event PropertyChangedEventHandler PropertyChanged;

        public ExcercisesViewModel(string toDoDbConnectionString)
        {
            keepFitContext = new KeepFitDataContext(toDoDbConnectionString);
        }

        private ObservableCollection<Excercise> allExcercises;
        public ObservableCollection<Excercise> AllExcercises
        {
            get { return allExcercises; }
            set
            {
                allExcercises = value;
                NotifyPropertyChanged("AllExcercises");
            }
        }

        // A list of all categories, used by the add task page.
        private List<ExcerciseCategory> allCategories;
        public List<ExcerciseCategory> AllCategories
        {
            get { return allCategories; }
            set
            {
                allCategories = value;
                NotifyPropertyChanged("AllCategories");
            }
        }

        public void SaveChanges()
        {
            keepFitContext.SubmitChanges();
        }

        // Query database and load the collections and list used by the pivot pages.
        public void LoadCollectionsFromDatabase()
        {

            // Specify the query for all to-do items in the database.
            var excercisesInDb = from Excercise excercise in keepFitContext.Excercises
                                select excercise;

            // Query the database and load all to-do items.
            AllExcercises = new ObservableCollection<Excercise>(excercisesInDb);

            // Specify the query for all categories in the database.
            var excercisesCategoriesInDb = from ExcerciseCategory category in keepFitContext.ExcercisesCategories
                                     select category;

            // Load a list of all categories.
            AllCategories = excercisesCategoriesInDb.ToList();

        }

        // Add a to-do item to the database and collections.
        public void AddExcerciseItem(Excercise newExcerciseItem)
        {
            // Add a to-do item to the data context.
            keepFitContext.Excercises.InsertOnSubmit(newExcerciseItem);

            // Save changes to the database.
            keepFitContext.SubmitChanges();

            // Add a to-do item to the "all" observable collection.
            AllExcercises.Add(newExcerciseItem);
        }

        public void AddCategoryItem(ExcerciseCategory category)
        {
            keepFitContext.ExcercisesCategories.InsertOnSubmit(category);
            keepFitContext.SubmitChanges();
            AllCategories.Add(category);
        }

        // Remove a to-do task item from the database and collections.
        public void DeleteExcerciseItem(Excercise excerciseForDelete)
        {

            // Remove the to-do item from the "all" observable collection.
            AllExcercises.Remove(excerciseForDelete);

            // Remove the to-do item from the data context.
            keepFitContext.Excercises.DeleteOnSubmit(excerciseForDelete);

            // Save changes to the database.
            keepFitContext.SubmitChanges();
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
