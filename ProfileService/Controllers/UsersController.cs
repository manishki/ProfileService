using ProfileService.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProfileService.Controllers
{
    public class UsersController : ApiController
    {
        // GET api/users
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        public IHttpActionResult Get(Guid id)
        {
            using (var context = new ProfileContext())
            {
                var profile = context.Users.ToArray();
                return Ok(profile);
            }            
        }
    }
}
