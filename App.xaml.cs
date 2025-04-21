using System.Configuration;
using System.Data;
using System.Windows;
using CodeBots.WpfApp.Properties;


namespace CodeBots.WpfApp;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : System.Windows.Application
{

    protected override void OnStartup(StartupEventArgs e){
        base.OnStartup(e);

        if(!String.IsNullOrEmpty(Settings.Default.Token)){
            var mainwindow = new MainWindow();
            mainwindow.Show();
        } else
        {
            var loginwindow = new LoginWindow();
            loginwindow.Show();
        }
        
    }
}

