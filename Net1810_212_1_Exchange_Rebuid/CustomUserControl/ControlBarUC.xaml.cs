using System.Windows.Controls;
using Exchange.WpfApp.ViewModels;

namespace Exchange.WpfApp.CustomUserControl;

public partial class ControlBarUC : UserControl
{
    public ControlBarViewModel ViewModel { get; set; }
    public ControlBarUC()
    {
        InitializeComponent();
        //Moi window se dung 1 view model rieng
        this.DataContext = ViewModel = new ControlBarViewModel();
    }
}