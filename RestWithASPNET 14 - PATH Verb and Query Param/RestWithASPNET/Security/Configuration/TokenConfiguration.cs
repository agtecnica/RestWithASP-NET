namespace RestWithASPNET.Security.Configuration
{
    public class TokenConfiguration
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }//emissor
        public int Seconds { get; set; }
    }
}
