using Exchange.Business;
using Exchange.Data.Models;
using Exchange.WpfApp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Exchange.WpfApp
{
    /// <summary>
    /// Interaction logic for welcome.xaml
    /// </summary>
    public partial class welcome : Window
    {
        public welcome()
        {
            InitializeComponent();
        }

        private async void userLogin1(object sender, RoutedEventArgs e)
        {
            var customerRepo = new CustomerBusiness();

            var customer = await customerRepo.checkAcountLogin("tran.thi.b@example.com", "password123");

            var customerResult = (Customer)customer.Data;

            if (customerResult is not null)
            {
                MessageBox.Show($"Hello {customerResult.FullName}", "Login Successful", MessageBoxButton.OK, MessageBoxImage.Information);
             
            
                wProduct wMyProductScreen = new wProduct(customerResult);
                wMyProductScreen.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("incorrect login!!! please try again", "Login Fail", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

        }

        private async void userLogin2(object sender, RoutedEventArgs e)
        {
            var customerRepo = new CustomerBusiness();

            var customer = await customerRepo.checkAcountLogin("nguyen.van.a@example.com", "securepass");

            var customerResult = (Customer)customer.Data;

            if (customerResult is not null)
            {
                MessageBox.Show($"Hello {customerResult.FullName}", "Login Successful", MessageBoxButton.OK, MessageBoxImage.Information);
            
                
                wProduct wMyProductScreen = new wProduct(customerResult);
                wMyProductScreen.Show();
                this.Close();

            }
            else
            {
                MessageBox.Show("incorrect login!!! please try again", "Login Fail", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


        }
    }
    }


