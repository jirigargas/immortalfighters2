namespace ImmortalFighters.WebApp.ApiModels
{
    public class RegisterRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }

    public static class RegisterRequestExtensions
    {
        public static bool IsValid(this RegisterRequest request)
        {
            return !string.IsNullOrWhiteSpace(request.Username)
                && request.Username.Length >= 4
                && !string.IsNullOrWhiteSpace(request.Password)
                && request.Password.Length >= 8
                && !string.IsNullOrWhiteSpace(request.Email);
        }
    }
}
