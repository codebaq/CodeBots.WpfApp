using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace CodeBots.WpfApp.Services;

public class DeviceService {

    private static readonly HttpClient client = new HttpClient();

    public static async Task<List<Device>> GetDevicesAsync()
    {
        string token = Properties.Settings.Default.Token;
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await client.GetAsync("http://localhost:3000/getallphones");
        var responsebody = await response.Content.ReadAsStringAsync();

        var result = JsonConvert.DeserializeObject<List<Device>>(responsebody);
        return  result;
    }
}