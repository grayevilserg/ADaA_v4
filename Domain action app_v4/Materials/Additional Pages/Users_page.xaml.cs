using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace Domain_action_app_v4.Materials.Additional_Pages
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class Users_page : Page
    {
        public ObservableCollection<User> UserPropertys { get; set; }
        string username;

        public Users_page()
        {
            this.InitializeComponent();
            UserPropertys = new ObservableCollection<User>();
        }

        private void UsersPage_loaded(object sender, RoutedEventArgs e)
        {
            /*MyRing.IsActive = false;
            MyRing.Visibility = Visibility.Collapsed;*/
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            LoadingRing.IsActive = true;
            LoadingRing.Visibility = Visibility.Visible;
            if (SearchTextBox.Text != null)
            {
                username = SearchTextBox.Text;
                ActionManager.Exists(username);
                ActionManager.GetUserInfo(username, UserPropertys);
            }
            //else ;
            LoadingRing.IsActive = false;
            LoadingRing.Visibility = Visibility.Collapsed;

        }

        private void SetPasBut_Click(object sender, RoutedEventArgs e)
        {
            string password = PasswordTextBox.Text;
            ActionManager.ChangePassword(username, password);
        }

        private void RandPassBut_Click(object sender, RoutedEventArgs e)
        {
            PasswordTextBox.Text = ActionManager.RandPass();
        }
    }
}
