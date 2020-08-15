using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Action - Login
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string Username = string.Empty, Password = string.Empty;
                Username = Convert.ToString(txtUsername.Text);
                Password = Convert.ToString(txtPassword.Text);
                if(!string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password))
                {
                    NavigationService.Navigate(new ListViewPage(Username));
                }
                else
                {
                    MessageBox.Show("Please Enter Login Details","Login");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error Occured","Login");
            }
        }
    }
}
