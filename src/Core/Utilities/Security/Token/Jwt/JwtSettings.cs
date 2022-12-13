namespace Core.Utilities.Security.Token.Jwt
{
    public class JwtSettings
    {
        public string Key { get; set; }
        public int ValidateLifetime { get; set; }
        public string? ValidIssuer { get; set; }
        public string? ValidAudience { get; set; }
    }
}
