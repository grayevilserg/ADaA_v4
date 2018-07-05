using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Domain_action_app_v4.Materials.Additional_Pages;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace Domain_action_app_v4
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            MyFrame.Navigate(typeof(Users_page));
        }

        private void Menu_click(object sender, RoutedEventArgs e)
        {
            MenuView.IsPaneOpen = !MenuView.IsPaneOpen;
        }

        private void IconsListBox_changed(object sender, SelectionChangedEventArgs e)
        {
            if (Users_item.IsSelected)
            {
                MyFrame.Navigate(typeof(Users_page));
                Title.Text = "Users";
            }
            else if (Groups_item.IsSelected)
            {
                MyFrame.Navigate(typeof(Groups_page));
                Title.Text = "Groups";
            }
            else if (Options_item.IsSelected)
            {
                MyFrame.Navigate(typeof(Options_page));
                Title.Text = "Options";
            }
        }
    }
}
