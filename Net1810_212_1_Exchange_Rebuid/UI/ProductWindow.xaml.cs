using System.Collections.Generic;
using System.IO;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Exchange.Business;
using Exchange.Data.Models;
using Exchange.WpfApp.UI;
using Exchange.WpfApp.ViewModels;
using MaterialDesignThemes.Wpf;

namespace Exchange.WpfApp
{
    public partial class ProductWindow : Window
    {
        private const string BLANK_IMG_PATH = "blank_img.jpg";

        private readonly ProductsBusiness _productBusiness = new ProductsBusiness();
        private readonly UserHaveBusiness _userHaveBusiness = new UserHaveBusiness();
        private readonly CustomerBusiness _customerBusiness = new CustomerBusiness();
        private readonly Customer customerLogin;
        private readonly int UserHaverIDisSelected;
        //Product cua seller
        public Product Product { get; set; }

        public ProductWindow(int productID)
        {
            //MUST start the async initialization

            InitializeComponent();
            showInforProduct(productID);
            btnTradeName.Visibility=  Visibility.Hidden;
            DataContext = this;

        }
        public ProductWindow(int UserHaverID, Customer customer)
        {
            //MUST start the async initialization
          
            InitializeComponent();
            InitializeAsync(UserHaverID);
            DataContext = this;
            customerLogin=customer;
            UserHaverIDisSelected = UserHaverID;
        
        }

        private async void InitializeAsync(int UserHaverID)
        {
            UserHave userHave = ( await _userHaveBusiness.findMyHaveProductById(UserHaverID)).Data as UserHave;
            string baseDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //navigate up one level to get to the project directory
            string projectDirectory = Directory.GetParent(baseDirectory).Parent.Parent.FullName;
            var result = await _productBusiness.findProductById(userHave.ProductId);
            if (result?.Data is not null)
            {
                Product = (Product)result.Data;
                if (String.IsNullOrEmpty(Product.Img))
                    Product.Img = Path.Combine(projectDirectory, "wwwroot", BLANK_IMG_PATH);
                else
                {
                    Product.Img =
                        Path.Combine(projectDirectory, "wwwroot", Product.Img);
                }

                await RetrieveAuthorNameAsync(Product.CustomerId);
                DataContext = Product;
            }
            else
            {
                Product = new Product();
            }
        }

        private async void showInforProduct(int productID)
        {
            btnTradeName.Click -= OpenOrderWindow;
            string baseDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //navigate up one level to get to the project directory
            string projectDirectory = Directory.GetParent(baseDirectory).Parent.Parent.FullName;
            var result = await _productBusiness.findProductById(productID);
            if (result?.Data is not null)
            {
                Product = (Product)result.Data;
                if (String.IsNullOrEmpty(Product.Img))
                    Product.Img = Path.Combine(projectDirectory, "wwwroot", BLANK_IMG_PATH);
                else
                {
                    Product.Img =
                        Path.Combine(projectDirectory, "wwwroot", Product.Img);
                }

                await RetrieveAuthorNameAsync(Product.CustomerId);
                DataContext = Product;
            }
            else
            {
                Product = new Product();
            }
        }


        private async Task RetrieveAuthorNameAsync(int customerId)
        {
            var authorResult = await _customerBusiness.GetById(customerId);
            if (authorResult?.Data is not null)
            {
                var author = (Customer)authorResult.Data;
                Author.ItemsSource = new List<Customer>() { author };
            }
        }

        private void OpenOrderWindow(object sender, RoutedEventArgs e)
        {
           

            var  wUserwantScreen = new wUserWant(customerLogin, UserHaverIDisSelected);
            this.Hide();
            wUserwantScreen.Show();
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}