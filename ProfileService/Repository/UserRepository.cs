using ProfileService.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProfileService.Repository
{
    public class UserRepository : IDisposable, IUserRepository
    {
        private readonly IProfileContext _profileContext;

        public UserRepository(IProfileContext profileContext)
        {
            //ProfileContext profileContext
            _profileContext = profileContext;
        }
        public IList<User> Get()
        {
            return _profileContext.Users.ToArray();
        }

        public User Get(Guid id)
        {
            return _profileContext.Users.Find(id);
        }

        public int Put(User user)
        {
            return _profileContext.SaveChanges();
        }
        public User Post(User user)
        {
            var newUser = _profileContext.Users.Add(user);
            _profileContext.SaveChanges();
            return newUser;
        }
        public User Delete(User user)
        {
            var userToDelete = _profileContext.Users.Remove(user);
            _profileContext.SaveChanges();
            return userToDelete;
        }

        public void Dispose()
        {
            _profileContext.Dispose();
        }
    }
}