using dotnetcore_model;
using System;
using System.Collections.Generic;

namespace dotnetcore_respository
{
    public interface ICustomerRespository
    {
        List<Customer> GetCustomers(int amount, string sort);

        Customer GetSingleCustomer(int customerId);

        bool InsertCustomer(Customer ourCustomer);

        bool DeleteCustomer(int customerId);

        bool UpdateCustomer(Customer ourCustomer);
    }
}
