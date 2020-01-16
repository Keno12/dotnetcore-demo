using Dapper;
using dotnetcore_model;
using dotnetcore_respository.BaseRepository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetcore_respository
{
    public class CustomerRespository : RepositoryBase<Customer>, ICustomerRespository
    {
        private readonly IDbConnection _db;

        public CustomerRespository()
        {
            _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }

        public async Task<List<Customer>> GetCustomersAsync(int amount, string sort)
        {
            string sql = string.Format("SELECT TOP {0} [CustomerID],[CustomerFirstName],[CustomerLastName],[IsActive] FROM [Customer] ORDER BY CustomerID {1}", amount, sort);
            return await Select(sql);
        }

        public async Task<Customer> GetCustomerAsync(Guid CustomerID)
        {
            string sql = @"SELECT [CustomerID],[CustomerFirstName],[CustomerLastName],[IsActive] FROM [Customer] WHERE CustomerID =@CustomerID";
            return await Detail(CustomerID, sql);
        }

        public async Task<bool> InsertCustomerAsync(Customer customer)
        {
            string sql = @"INSERT Customer([CustomerFirstName],[CustomerLastName],[IsActive]) values (@CustomerFirstName, @CustomerLastName, @IsActive)";
            return await Insert(customer, sql);

        }

        public async Task<bool> DeleteCustomerAsync(Guid CustomerID)
        {
            string sql = @"DELETE FROM[Customer] WHERE CustomerID = @CustomerID";
            return await Delete(CustomerID, sql);
        }

        public async Task<bool> UpdateCustomerAsync(Customer customer)
        {
            string sql = "UPDATE [Customer] SET [CustomerFirstName] = @CustomerFirstName ,[CustomerLastName] = @CustomerLastName, [IsActive] = @IsActive WHERE CustomerID = ";
            return await Update(customer, sql);
        }
    }
}
