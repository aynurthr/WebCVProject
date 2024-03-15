using WebCV.Infrastructure.Abstracts;

namespace WebCV.Application.Services.Identity
{
    public class FakeIdentityService : IIdentityService
    {
        public int? GetPrincipialId()
        {
            return null;
        }
    }
}
