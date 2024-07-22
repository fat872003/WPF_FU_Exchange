using Exchange.Business;
using Exchange.Data.Models;
using Exchange.WpfApp.UI;
using Exchange.WpfApp;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

       

       
        private async void btnlogin(object sender, RoutedEventArgs e)
        {
            var customerRepo = new CustomerBusiness();

            var customer = await customerRepo.checkAcountLogin(txtEmail.Text, txtPass.Text);

            var customerResult = (Customer)customer.Data;

            if (string.IsNullOrEmpty(txtEmail.Text)|| string.IsNullOrEmpty(txtPass.Text))
            {
                MessageBox.Show("please enter information", "Login Fail", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
            }

            if (customerResult is not null )
            {
                MessageBox.Show($"Hello {customerResult.FullName}", "Login Successful", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Hide();
                // em quen sua ten product
                wProduct wMyProductScreen = new wProduct(customerResult);
                wMyProductScreen.Show();   
            }
            else
            {
                MessageBox.Show("incorrect login!!! please try again", "Login Fail", MessageBoxButton.OK, MessageBoxImage.Error);
                    return ;
            }   



        }
    }
}
