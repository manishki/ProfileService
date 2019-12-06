using log4net;
using ProfileService.DataBase;
using ProfileService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ProfileService.Controllers
{
    public class UsersController : ApiController
    {
        ILog log = log4net.LogManager.GetLogger(typeof(UsersController));

        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        // GET api/users
        public IHttpActionResult Get()
        {
            log.Debug("Fetching all the record from the database.");
            var profiles = _userRepository.Get();
            log.Debug($"Successfully got {profiles.Count()} records");
            return Ok(profiles);

        }

        public IHttpActionResult Get(Guid id)
        {
            log.Debug($"Fetching the record from the database with {id}");
            var profile = _userRepository.Get(id);
            log.Debug($"Fetched the record from the database with {id}");
            return Ok(profile);
        }

        public IHttpActionResult Post(User user)
        {
            var newUser = _userRepository.Post(user);
            log.Debug($"Record added to the database with id {user.Id}");
            return Ok(newUser);

        }
        public IHttpActionResult Put(User user)
        {
            //using (var profile = new ProfileContext())
            //{
            var userTobeUpdated = _userRepository.Get(user.Id);
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

                _userRepository.Put(userTobeUpdated);
                log.Debug($"Record updated successfuly with Id : {user.Id}");
                return Ok(user);
            }

            //}
        }
        public IHttpActionResult Delete(Guid id)
        {
            var profile = _userRepository.Get(id);
            if (profile == null)
            {
                log.Error($"No record found with id {profile.Id}");
                return NotFound();
            }
            else
            {
                profile = _userRepository.Delete(profile);
                log.Debug($"Record deleted successfuly with Id : {profile.Id}");
                return Ok(profile);
            }
        }
    }
}
