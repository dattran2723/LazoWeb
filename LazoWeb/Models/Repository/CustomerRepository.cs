using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazoWeb.Models.Repository
{
    public interface ICustomerRepository
    {
        IQueryable<Customer> GetCustomers();
    }
    public class CustomerRepository : ICustomerRepository
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public CustomerRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IQueryable<Customer> GetCustomers()
        {
            return db.Customers;
        }

    }
}
