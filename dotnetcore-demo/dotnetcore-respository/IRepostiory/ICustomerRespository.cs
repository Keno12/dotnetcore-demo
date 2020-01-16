using dotnetcore_model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnetcore_respository
{
    public interface ICustomerRespository
    {
        Task<List<Customer>> GetCustomersAsync(int amount, string sort);

        Task<Customer> GetCustomerAsync(Guid CustomerID);

        Task<bool> InsertCustomerAsync(Customer customer);

        Task<bool> DeleteCustomerAsync(Guid CustomerID);

        Task<bool> UpdateCustomerAsync(Customer customer);
    }
}
