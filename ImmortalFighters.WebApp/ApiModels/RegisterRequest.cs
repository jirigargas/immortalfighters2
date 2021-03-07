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
                && !string.IsNullOrWhiteSpace(request.Password)
                && !string.IsNullOrWhiteSpace(request.Email);
        }
    }
}
