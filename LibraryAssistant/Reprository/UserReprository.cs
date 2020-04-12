using LibraryAssistant.Core.Entities;
using LibraryAssistant.Core.Interfaces.Reprository;
using LibraryAssistant.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAssistant.API.Reprository
{
    public class UserReprository : IUserReprository
    {
        private DataContext _dataContext;

        public UserReprository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void AddUser(Users user)
        {



            _dataContext.Users.Add(user);
        }

        public async Task<bool> SaveAsync()
        {
            return (await _dataContext.SaveChangesAsync()) >= 0;

        }
    }
}
