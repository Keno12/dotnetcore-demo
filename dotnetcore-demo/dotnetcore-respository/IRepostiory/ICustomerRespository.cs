using dotnetcore_model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnetcore_respository
{
    public interface ICustomerRespository
    {
        List<Customer> GetCustomers(int amount, string sort);

        Task<Customer> GetCustomer(Guid CustomerID);

        bool InsertCustomer(Customer ourCustomer);

        Task<bool> DeleteCustomer(Guid CustomerID);

        bool UpdateCustomer(Customer ourCustomer);
    }
}
