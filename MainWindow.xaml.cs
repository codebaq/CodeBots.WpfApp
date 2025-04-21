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
using CodeBots.WpfApp.Views;

namespace CodeBots.WpfApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        MainContent.Content = new DashboardControl();
    }

    private void Navigate(object sender, RoutedEventArgs e)
    {
        var button = sender as System.Windows.Controls.Button;
        var section = button?.Tag?.ToString();

        switch(section)
        {
            case "Dashboard" :
                MainContent.Content = new DashboardControl();
                break;
            case "Dispositivos": 
                MainContent.Content = new DispositivosControl();
                break;
        }
    }
}