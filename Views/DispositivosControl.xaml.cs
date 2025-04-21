using System.Windows;
using System.Windows.Controls;
using CodeBots.WpfApp.Services;

namespace CodeBots.WpfApp.Views
{
    
    public partial class DispositivosControl : System.Windows.Controls.UserControl
    {
        public DispositivosControl()
        {
            InitializeComponent();
            _= LoadDevicesAsync();
        }

        private async Task LoadDevicesAsync()
        {
            try
            {
                List<Device> devices = await DeviceService.GetDevicesAsync();
                DeviceList.ItemsSource = devices;
            }
            catch
            {
                System.Windows.MessageBox.Show("error al cargar los dispositivos");     
            }
        }

        private async void DeviceList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var DeviceSelected = DeviceList.SelectedItem as Device;
            if(DeviceSelected != null)
            {
                var ModeloPhone = DeviceSelected.Modelo.Split('-')[1].Trim();
                DeviceModelo.Text = DeviceSelected.Modelo;
                await DeviceControlService.StartScrcpy(DeviceSelected.Ip, ModeloPhone, ScrcpyHost);
            }
        }
    }
}
