using Microsoft.AspNetCore.Identity;

namespace CMS.Domain.Entities
{
    public class User : IdentityUser<int>, ICreationTrackable, ISoftDeleteable
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string? ThirdName { get; set; }
        public string LastName { get; set; }
        public string? ProfileImagePath { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int? DeletedBy { get; set; }

        public IList<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
        public User? CreatedByUser { get; set; }
        public User? DeletedByUser { get; set; }
    }
}



