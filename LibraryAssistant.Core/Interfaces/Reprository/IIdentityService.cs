using LibraryAssistant.Core.Models;

using System.Threading.Tasks;

namespace LibraryAssistant.Core.Interfaces.Reprository
{
    public interface IIdentityService
    {
        Task<AuthenticationResult> RegisterAsync(string email, string password);

        Task<AuthenticationResult> LoginAsync(string email, string password);       
    }
}
