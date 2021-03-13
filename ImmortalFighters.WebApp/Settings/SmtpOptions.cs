namespace ImmortalFighters.WebApp.Settings
{
    public class SmtpOptions
    {
        public string Server { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string SenderName { get; set; }
        public string SenderAddress { get; set; }
    }
}
