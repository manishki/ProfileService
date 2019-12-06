using ProfileService.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ProfileService.Controllers
{
    public class UsersController : ApiController
    {
        // GET api/users
        public IHttpActionResult Get()
        {
            using (var context = new ProfileContext())
            {
                var profiles = context.Users.ToArray();
                return Ok(profiles);
            }
        }

        public IHttpActionResult Get(Guid id)
        {
            using (var context = new ProfileContext())
            {
                var profile = context.Users.Find(id);
                return Ok(profile);
            }
        }

        public IHttpActionResult Post(User user)
        {
            using (var profile = new ProfileContext())
            {
                var newUser = profile.Users.Add(user);
                profile.SaveChanges();
                return Ok(newUser);
            }

        }
        public IHttpActionResult Put(User user)
        {
            using (var profile = new ProfileContext())
            {
                var userTobeUpdated = profile.Users.Find(user.Id);
                if (user == null)
                {
                    return NotFound();
                }
                else
                {
                    userTobeUpdated.Name = user.Name;
                    userTobeUpdated.Password = user.Password;
                    userTobeUpdated.EmailId = user.EmailId;
                    userTobeUpdated.ContectNumber = user.ContectNumber;
                    userTobeUpdated.ImageUrl = user.ImageUrl;

                    //user = profile.Users.Add(userTobeUpdated);
                    profile.SaveChanges();
                    return Ok(user);
                }

            }
        }
        public IHttpActionResult Delete(Guid id)
        {
            using (var profile = new ProfileContext())
            {
                var user = profile.Users.Find(id);
                if (user == null)
                {
                    return NotFound();
                }
                else
                {
                    user = profile.Users.Remove(user);
                    profile.SaveChanges();
                    return Ok(user);
                }

            }
        }
    }
}
