using ProfileService.DataBase;
using System;
using System.Collections.Generic;

namespace ProfileService.Repository
{
    public interface IUserRepository
    {
        User Delete(User user);
        void Dispose();
        IList<User> Get();
        User Get(Guid id);
        User Post(User user);
        int Put(User user);
    }
}