using System.Text.Json.Serialization;

namespace CMS.Application.Features.Auth.Models
{
    public class AuthDTO
    {
        public int UserId { get; set; }
        public string AccessToken { get; set; }
        public DateTime ExpiresOn { get; set; }

        [JsonIgnore]
        public string RefreshToken { get; set; }
        [JsonIgnore]
        public DateTime RefreshTokenExpiration { get; set; }
    }
}


