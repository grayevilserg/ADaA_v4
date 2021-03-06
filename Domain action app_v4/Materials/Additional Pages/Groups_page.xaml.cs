﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Domain_action_app_v4.Materials.Classes;
using System.Collections.ObjectModel;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace Domain_action_app_v4.Materials.Additional_Pages
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class Groups_page : Page
    {
        private ObservableCollection<Groups> Groups;

        public Groups_page()
        {
            this.InitializeComponent();
            Groups = ActionManager.GetGroups();
        }

        private void GroupsPage_loaded(object sender, RoutedEventArgs e)
        {
            /*GrRing.IsActive = true;
            GrRing.Visibility = Visibility.Visible;*/

            

            /*GrRing.IsActive = false;
            GrRing.Visibility = Visibility.Collapsed;*/
        }
    }
}
