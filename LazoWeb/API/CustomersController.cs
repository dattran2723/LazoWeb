using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LazoWeb.Models;
using LazoWeb.Models.Repository;

namespace LazoWeb.API
{
    public class CustomersController : ApiController
    {
        private ICustomerRepository customerRepository;

        public CustomersController()
        {
            this.customerRepository = new CustomerRepository(new ApplicationDbContext());
        }

        [HttpGet]
        [Route("api/customers")]
        public DataTableResponse GetCustomers()
        {
            var customer = customerRepository.GetCustomers();
            return new DataTableResponse
            {
                recordsTotal = customer.Count(),
                recordsFiltered = customer.Count(),
                data = customer.OrderByDescending(x => x.RegisterDate).ToArray()
            };
        }
    }
}
