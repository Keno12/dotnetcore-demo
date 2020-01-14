using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetcore_model;
using dotnetcore_respository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dotnetcore_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private CustomerRespository _customerRespository;

        public CustomerController()
        {
            _customerRespository = new CustomerRespository();
        }

        // GET: /Customer
        [Route("Customers")]
        [HttpGet]
        public List<Customer> Get()
        {
            return _customerRespository.GetCustomers(10, "ASC");
        }

        // GET: /Customer/10/ASC
        [Route("Customers/{amount}/{sort}")]
        [HttpGet]
        public List<Customer> Get(int amount, string sort)
        {
            return _customerRespository.GetCustomers(amount, sort);
        }

        // GET: /Customer/5
        [Route("Customers/{id}")]
        [HttpGet]
        public async Task<Customer> Get(Guid id)
        {
            try
            {
              return await _customerRespository.GetCustomer(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

        }

        // POST: /Customer
        [Route("Customers")]
        [HttpPost]
        public bool Post([FromBody]Customer ourCustomer)
        {
            //return true;
            return _customerRespository.InsertCustomer(ourCustomer);
        }

        // PUT: api/Customer/5
        [Route("Customers")]
        [HttpPut]
        public bool Put([FromBody]Customer ourCustomer)
        {
            return _customerRespository.UpdateCustomer(ourCustomer);
        }

        // DELETE: api/Customer/5
        [Route("Customers/{id}")]
        [HttpDelete]
        public async Task DeleteCustomer(Guid id)
        {
            try
            {
                await _customerRespository.DeleteCustomer(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

        }
    }
}