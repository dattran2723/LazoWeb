using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LazoWeb.Models.Repository
{
    public interface IUserRepository
    {
        IQueryable<ApplicationUser> GetUsers();
    }
    public class UserRepository : IUserRepository
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public UserRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IQueryable<ApplicationUser> GetUsers()
        {
            return db.Users;
        }
    }
    public class DataTableResponse
    {
        public int draw { get; set; }
        public long recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public object[] data { get; set; }
        public string error { get; set; }
    }
}