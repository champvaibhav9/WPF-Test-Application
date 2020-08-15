using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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
    /// Interaction logic for ListView.xaml
    /// </summary>
    public partial class ListViewPage : Page
    {
        string Title = string.Empty;
        public ListViewPage()
        {
            InitializeComponent();
        }

        public ListViewPage(string  Username) : this()
        {
            Title = Username;
            this.Loaded += new RoutedEventHandler(Page_Loaded);

        }
        void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                lblTitle.Content = Title;
                List<User> lstUsers = GetUsers();
                lstViewTitle.ItemsSource = lstUsers;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured", "List View");
            }

        }

        private void lstViewTitle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var selectedItems = lstViewTitle.SelectedItems;
                User objUser = (User)selectedItems[0];      
                NavigationService.Navigate(new DisplayView(objUser));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured", "List View");
            }
        }

        #region API Call

        private List<User> GetUsers()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");
                client.DefaultRequestHeaders.Accept.Add(
                   new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("/todos").Result;
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    List<User> list = JsonConvert.DeserializeObject<List<User>>(result);
                    return list;
                }
                else
                {
                    return new List<User>();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }
        #endregion
    }
}
