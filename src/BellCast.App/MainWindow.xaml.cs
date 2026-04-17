using Wpf.Ui.Controls;

namespace BellCast.App;

public partial class MainWindow : FluentWindow
{
    public MainWindow()
    {
        InitializeComponent();

        Loaded += (_, _) => RootNavigation.Navigate(typeof(Views.DashboardPage));
    }
}
