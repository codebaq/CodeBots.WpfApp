using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class AuthService
{
    private static readonly HttpClient client = new HttpClient();

    public static async Task<AuthResponse> Login(string username, string password)
    {
        var UsuarioData = new 
        {
           User = username,
           Password = password
        };

        var UsuarioDataJson = JsonConvert.SerializeObject(UsuarioData);
        var data = new StringContent(UsuarioDataJson,Encoding.UTF8, "application/json");

        var response = await client.PostAsync("http://localhost:3000/login", data);
        var responsebody = await response.Content.ReadAsStringAsync();

        var result = JsonConvert.DeserializeObject<AuthResponse>(responsebody);

        return result ?? new AuthResponse {Success = false, Message = "Repuesta invalida del servidor"};
    }
}