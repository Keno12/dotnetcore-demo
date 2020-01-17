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
        public async Task<List<Customer>> Get()
        {
            try
            {
                return await _customerRespository.GetCustomersAsync(10, "ASC");
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

        }

        // GET: /Customer/10/ASC
        [Route("Customers/{amount}/{sort}")]
        [HttpGet]
        public async Task<List<Customer>> Get(int amount, string sort)
        {
            return await _customerRespository.GetCustomersAsync(amount, sort);

        }

        // GET: /Customer/5
        [Route("Customers/{id}")]
        [HttpGet] 
        public async Task<Customer> Get(Guid id)
        {
            try
            {
                return await _customerRespository.GetCustomerAsync(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

        }

        // POST: /Customer
        [Route("Customers")]
        [HttpPost]
        public async Task<bool> Post([FromBody]Customer ourCustomer)
        {

            return await _customerRespository.InsertCustomerAsync(ourCustomer);
        }

        // PUT: api/Customer/5
        [Route("Customers")]
        [HttpPut]
        public async Task<bool> Put([FromBody]Customer ourCustomer)
        {
            return await _customerRespository.UpdateCustomerAsync(ourCustomer);
        }

        // DELETE: api/Customer/5
        [Route("Customers/{id}")]
        [HttpDelete]
        public async Task DeleteCustomer(Guid id)
        {
            try
            {
                await _customerRespository.DeleteCustomerAsync(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

        }
    }
}