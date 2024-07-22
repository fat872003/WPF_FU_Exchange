using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Exchange.Business;
using Exchange.Business.Base;
using Exchange.Data.Models;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Exchange.WpfApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private bool _isLoaded = false;
        public ICommand LoadedWindowCommand { get; set; }
        public ICommand ProductCommand { get; set; }
        
        public MainViewModel()
        {
            // LoadedWindowCommand =
            //     // ReSharper disable once ComplexConditionExpression
            //     new RelayCommand<object>((p) => true,
            //         p =>
            //         {
            //             if (!_isLoaded)
            //             {
            //                 _isLoaded = true;
            //                 var wd = new LoginWindow();
            //                 wd.ShowDialog();
            //             }
            //         }
            //     );
            
            ProductCommand =
                new RelayCommand<object>(p => true,
                    p =>
                    {
                        //product window's parameter is passed by View Product List window
                      
                    }
                );
        }
    }
}