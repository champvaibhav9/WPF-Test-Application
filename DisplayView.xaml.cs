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
    /// Interaction logic for DisplayView.xaml
    /// </summary>
    public partial class DisplayView : Page
    {
        List<User> UserDetails = new List<User>();
        public DisplayView()
        {
            InitializeComponent();
        }
        public DisplayView(User objUser) : this()
        {
            this.UserDetails.Add(objUser);
            this.Loaded += new RoutedEventHandler(Page_Loaded);
        }
        void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgrdUser.ItemsSource = this.UserDetails;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error Occured", "Display View");
            }
        }

    }
}
