public class AuthResponse
{
    
    public bool Success { get; set; }

    
    public string Message { get; set; }

    
    public string Token { get; set; } // puede ser null si falla
}