using LazoWeb.Models;
using LazoWeb.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LazoWeb.API
{
    public class UsersController : ApiController
    {
        private IUserRepository userRepository;

        public UsersController()
        {
            this.userRepository = new UserRepository(new ApplicationDbContext());
        }

        [HttpGet]
        [Route("api/users")]
        public DataTableResponse GetUsers()
        {
            var users = userRepository.GetUsers();
            return new DataTableResponse
            {
                recordsTotal = users.Count(),
                recordsFiltered = users.Count(),
                data = users.OrderByDescending(x=>x.CreatedDate).ToArray()
            };
        }
    }
}
