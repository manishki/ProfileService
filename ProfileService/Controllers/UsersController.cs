using log4net;
using ProfileService.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ProfileService.Controllers
{
    public class UsersController : ApiController
    {
        ILog log = log4net.LogManager.GetLogger(typeof(UsersController));
        // GET api/users
        public IHttpActionResult Get()
        {
            using (var context = new ProfileContext())
            {
                log.Debug("Fetching all the record from the database.");
                var profiles = context.Users.ToArray();
                log.Debug($"Successfully got {profiles.Length} records");
                return Ok(profiles);
            }
        }

        public IHttpActionResult Get(Guid id)
        {
            using (var context = new ProfileContext())
            {
                log.Debug($"Fetching the record from the database with {id}");
                var profile = context.Users.Find(id);
                log.Debug($"Fetched the record from the database with {id}");
                return Ok(profile);
            }
        }

        public IHttpActionResult Post(User user)
        {
            using (var profile = new ProfileContext())
            {
                var newUser = profile.Users.Add(user);
                profile.SaveChanges();
                log.Debug($"Record added to the database with id {user.Id}");
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
                    log.Error($"No record found with id {user.Id}");
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
                    log.Debug($"Record updated successfuly with Id : {user.Id}");
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
                    log.Error($"No record found with id {user.Id}");
                    return NotFound();
                }
                else
                {
                    user = profile.Users.Remove(user);
                    profile.SaveChanges();
                    log.Debug($"Record deleted successfuly with Id : {user.Id}");
                    return Ok(user);
                }

            }
        }
    }
}
