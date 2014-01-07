﻿using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Maps.Controls;
using Microsoft.Phone.Maps.Services;
using Microsoft.Phone.Shell;
using KeepFit.Phone.Resources;
using KeepFit.Phone.ViewModels;

namespace KeepFit.Phone
{
    public partial class MainPage : PhoneApplicationPage
    {
        GeoCoordinateWatcher gcw;
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the LongListSelector control to the sample data
            DataContext = App.ViewModel;

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }
        void gcw_PositionChanged(object sender,
GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            Debug.WriteLine("New position:" + e.Position.Location.Latitude + "," +
        e.Position.Location.Longitude);

            map.Center = e.Position.Location;
            map.Heading = e.Position.Location.Course;
        }
        void gcw_StatusChanged(object sender, GeoPositionStatusChangedEventArgs e)
        {
            Debug.WriteLine("New status: " + e.Status);

            if (e.Status == GeoPositionStatus.Ready)
            {
                map.Center = gcw.Position.Location;
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            gcw = new GeoCoordinateWatcher(GeoPositionAccuracy.High);
            gcw.PositionChanged += gcw_PositionChanged;
            gcw.StatusChanged += gcw_StatusChanged;

            gcw.Start();


            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
        }

        // Handle selection changed on LongListSelector
        private void MainLongListSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // If selected item is null (no selection) do nothing
            //if (MainLongListSelector.SelectedItem == null)
            //    return;

            //// Navigate to the new page
            //NavigationService.Navigate(new Uri("/DetailsPage.xaml?selectedItem=" + (MainLongListSelector.SelectedItem as ItemViewModel).ID, UriKind.Relative));

            //// Reset selected item to null (no selection)
            //MainLongListSelector.SelectedItem = null;
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}