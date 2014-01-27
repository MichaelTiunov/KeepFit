using System;
using System.Windows;
using System.Windows.Controls;
using KeepFit.WP.Model;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace KeepFit.WP
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            DataContext = App.ViewModel;

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void newTaskAppBarButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/NewTaskPage.xaml", UriKind.Relative));
        }

        private void deleteExcerciseButton_Click(object sender, RoutedEventArgs e)
        {
            // Cast the parameter as a button.
            var button = sender as Button;

            if (button != null)
            {
                // Get a handle for the to-do item bound to the button.
                var excerciseForDelete = button.DataContext as Excercise;

                App.ViewModel.DeleteExcerciseItem(excerciseForDelete);
            }

            // Put the focus back to the main page.
            Focus();
        }

        private void DeleteWorkoutButtonClick(object sender, RoutedEventArgs e)
        {
            // Cast the parameter as a button.
            var button = sender as Button;

            if (button != null)
            {
                // Get a handle for the to-do item bound to the button.
                var workout = button.DataContext as Workout;

                App.ViewModel.DeleteWorkoutItem(workout);
            }

            // Put the focus back to the main page.
            Focus();
        }

        private void deleteCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            // Cast the parameter as a button.
            var button = sender as Button;

            if (button != null)
            {
                // Get a handle for the to-do item bound to the button.
                var category = button.DataContext as ExcerciseCategory;

                App.ViewModel.DeleteExcerciseCategoryItem(category);
            }

            // Put the focus back to the main page.
            Focus();
        }

        private void ExcercisesPanorama_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PanoramaItem item = sender as PanoramaItem;
            ApplicationBar.Buttons.RemoveAt(0);
            ApplicationBarIconButton button = new ApplicationBarIconButton();
            button.IconUri = new Uri("/Images/appbar.add.rest.png");
            ApplicationBar.Buttons.Remove(button);
            switch (item.Header.ToString())
            {
                case "Workout":
                    button.Click += addNewWorkoutItem;
                    break;
                case "Category":
                    button.Click += addewCategoryItem;
                    break;
                case "Excercise":
                    button.Click += addNewExcerciseItem;
                    break;
            }
            ApplicationBar.Buttons.Add(button);
        }


        void addNewWorkoutItem(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        void addNewExcerciseItem(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        void addewCategoryItem(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}