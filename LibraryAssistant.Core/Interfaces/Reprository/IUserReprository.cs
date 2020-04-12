

using LibraryAssistant.Core.Entities;
using System.Threading.Tasks;

namespace LibraryAssistant.Core.Interfaces.Reprository
{
    public interface IUserReprository
    {
        void AddUser(Users user);

        Task<bool> SaveAsync();
       
    }
}
