using System.Windows;
using System.Diagnostics;
using CodeBots.WpfApp.Properties;


namespace CodeBots.WpfApp
{
    public partial class LoginWindow  : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private async void Login (object sender, RoutedEventArgs e)
        {
            var user = UserNameBox.Text;
            var password = PasswordBox.Password;

            var result = await AuthService.Login(user, password);

            if(!result.Success)
            {
                LoginStatus.Text = result.Message;
            } else if(result.Success)
            {
                Settings.Default.Token = result.Token;
                Settings.Default.Save();
                var mainwindow = new MainWindow();
                mainwindow.Show();
                this.Close();
            }
            Console.WriteLine(result.Message);
        }
    }
}