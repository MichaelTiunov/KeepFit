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


        private void deleteTaskButton_Click(object sender, RoutedEventArgs e)
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
    }
}