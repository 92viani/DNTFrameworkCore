using System.Security.Claims;

namespace DNTFrameworkCore.TestWebApp.Domain.Identity
{
    public class RoleClaim : ModificationTrackingEntity
    {
        public const int MaxClaimTypeLength = 256;

        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }

        public Role Role { get; set; }
        public long RoleId { get; set; }

        public Claim ToClaim()
        {
            return new Claim(ClaimType, ClaimValue);
        }

        public void InitializeFromClaim(Claim claim)
        {
            ClaimType = claim.Type;
            ClaimValue = claim.Value;
        }
    }
}