/* 
    Copyright (c) 2011 Microsoft Corporation.  All rights reserved.
    Use of this sample source code is subject to the terms of the Microsoft license 
    agreement under which you licensed this sample source code and is provided AS-IS.
    If you did not accept the terms of the license agreement, you are not authorized 
    to use this sample source code.  For the terms of the license, please see the 
    license agreement between you and Microsoft.
  
    To see all Code Samples for Windows Phone, visit http://go.microsoft.com/fwlink/?LinkID=219604 
  
*/
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

// Directive for the data model.
using LocalDatabaseSample.Model;


namespace LocalDatabaseSample.ViewModel
{
    public class ToDoViewModel : INotifyPropertyChanged
    {
        // LINQ to SQL data context for the local database.
        private ToDoDataContext toDoDB;

        // Class constructor, create the data context object.
        public ToDoViewModel(string toDoDBConnectionString)
        {
            toDoDB = new ToDoDataContext(toDoDBConnectionString);
        }

        // All to-do items.
        private ObservableCollection<Excercise> _allExcercises;
        public ObservableCollection<Excercise> AllExcercises
        {
            get { return _allExcercises; }
            set
            {
                _allExcercises = value;
                NotifyPropertyChanged("AllExcercises");
            }
        }

        // To-do items associated with the home category.
        private ObservableCollection<Excercise> _homeExcercises;
        public ObservableCollection<Excercise> HomeExcercises
        {
            get { return _homeExcercises; }
            set
            {
                _homeExcercises = value;
                NotifyPropertyChanged("HomeExcercises");
            }
        }

        // To-do items associated with the work category.
        private ObservableCollection<Excercise> _workExcercises;
        public ObservableCollection<Excercise> WorkExcercises
        {
            get { return _workExcercises; }
            set
            {
                _workExcercises = value;
                NotifyPropertyChanged("WorkExcercises");
            }
        }

        // To-do items associated with the hobbies category.
        private ObservableCollection<Excercise> _hobbiesExcercises;
        public ObservableCollection<Excercise> HobbiesExcercises
        {
            get { return _hobbiesExcercises; }
            set
            {
                _hobbiesExcercises = value;
                NotifyPropertyChanged("HobbiesExcercises");
            }
        }

        // A list of all categories, used by the add task page.
        private List<ExcerciseCategory> _categoriesList;
        public List<ExcerciseCategory> CategoriesList
        {
            get { return _categoriesList; }
            set
            {
                _categoriesList = value;
                NotifyPropertyChanged("CategoriesList");
            }
        }

        // Write changes in the data context to the database.
        public void SaveChangesToDB()
        {
            toDoDB.SubmitChanges();
        }

        // Query database and load the collections and list used by the pivot pages.
        public void LoadCollectionsFromDatabase()
        {

            // Specify the query for all to-do items in the database.
            var ExcercisesInDB = from Excercise todo in toDoDB.Items
                                select todo;

            // Query the database and load all to-do items.
            AllExcercises = new ObservableCollection<Excercise>(ExcercisesInDB);

            // Specify the query for all categories in the database.
            var toDoCategoriesInDB = from ExcerciseCategory category in toDoDB.Categories
                                     select category;


            // Query the database and load all associated items to their respective collections.
            foreach (ExcerciseCategory category in toDoCategoriesInDB)
            {
                switch (category.Name)
                {
                    case "Home":
                        HomeExcercises = new ObservableCollection<Excercise>(category.Excercises);
                        break;
                    case "Work":
                        WorkExcercises = new ObservableCollection<Excercise>(category.Excercises);
                        break;
                    case "Hobbies":
                        HobbiesExcercises = new ObservableCollection<Excercise>(category.Excercises);
                        break;
                    default:
                        break;
                }
            }

            // Load a list of all categories.
            CategoriesList = toDoDB.Categories.ToList();

        }

        // Add a to-do item to the database and collections.
        public void AddExcercise(Excercise newExcercise)
        {
            // Add a to-do item to the data context.
            toDoDB.Items.InsertOnSubmit(newExcercise);

            // Save changes to the database.
            toDoDB.SubmitChanges();

            // Add a to-do item to the "all" observable collection.
            AllExcercises.Add(newExcercise);

            // Add a to-do item to the appropriate filtered collection.
            switch (newExcercise.Category.Name)
            {
                case "Home":
                    HomeExcercises.Add(newExcercise);
                    break;
                case "Work":
                    WorkExcercises.Add(newExcercise);
                    break;
                case "Hobbies":
                    HobbiesExcercises.Add(newExcercise);
                    break;
                default:
                    break;
            }
        }

        // Remove a to-do task item from the database and collections.
        public void DeleteExcercise(Excercise toDoForDelete)
        {

            // Remove the to-do item from the "all" observable collection.
            AllExcercises.Remove(toDoForDelete);

            // Remove the to-do item from the data context.
            toDoDB.Items.DeleteOnSubmit(toDoForDelete);

            // Remove the to-do item from the appropriate category.   
            switch (toDoForDelete.Category.Name)
            {
                case "Home":
                    HomeExcercises.Remove(toDoForDelete);
                    break;
                case "Work":
                    WorkExcercises.Remove(toDoForDelete);
                    break;
                case "Hobbies":
                    HobbiesExcercises.Remove(toDoForDelete);
                    break;
                default:
                    break;
            }

            // Save changes to the database.
            toDoDB.SubmitChanges();
        }
        

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        // Used to notify Silverlight that a property has changed.
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
