using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Exchange.WpfApp.ViewModels;

public class ControlBarViewModel : BaseViewModel
{
    #region commands

    public ICommand CloseWindowCommand { get; set; }
    public ICommand MaximizeWindowCommand { get; set; }
    public ICommand MinimizeWindowCommand { get; set; }
    public ICommand MouseMoveWindowCommand { get; set; }

    #endregion

    public ControlBarViewModel()
    {
        CloseWindowCommand =
            // ReSharper disable once ComplexConditionExpression
            new RelayCommand<UserControl>((p) => { return p == null ? false : true; },
                p =>
                {
                    var window = GetWindowParent(p);
                    var w = window as Window;
                    if (w != null)
                    {
                        w.Close();
                    }
                });

        MaximizeWindowCommand =
            // ReSharper disable once ComplexConditionExpression
            new RelayCommand<UserControl>((p) => { return p == null ? false : true; },
                p =>
                {
                    var window = GetWindowParent(p);
                    var w = window as Window;
                    if (w != null)
                    {
                        w.WindowState = w.WindowState != WindowState.Maximized
                            ? WindowState.Maximized
                            : WindowState.Normal;
                    }
                });

        MinimizeWindowCommand =
            // ReSharper disable once ComplexConditionExpression
            new RelayCommand<UserControl>((p) => { return p == null ? false : true; },
                p =>
                {
                    var window = GetWindowParent(p);
                    var w = window as Window;
                    if (w != null)
                    {
                        w.WindowState = w.WindowState != WindowState.Minimized
                            ? WindowState.Minimized
                            : WindowState.Normal;
                    }
                });

        MouseMoveWindowCommand =
            // ReSharper disable once ComplexConditionExpression
            new RelayCommand<UserControl>((p) => { return p == null ? false : true; },
                p =>
                {
                    var window = GetWindowParent(p);
                    var w = window as Window;
                    if (w != null)
                    {
                        w.DragMove();
                    }
                });
    }


    //FE la base class cua Window
    private FrameworkElement GetWindowParent(UserControl p)
    {
        FrameworkElement parent = p;

        while (parent.Parent is not null)
            parent = parent.Parent as FrameworkElement;

        return parent;
    }
}