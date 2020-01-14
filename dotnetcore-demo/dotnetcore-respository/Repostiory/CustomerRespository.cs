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

        public List<Customer> GetCustomers(int amount, string sort)
        {
            return this._db.Query<Customer>("SELECT TOP " + amount + " [CustomerID],[CustomerFirstName],[CustomerLastName],[IsActive] FROM [Customer] ORDER BY CustomerID " + sort).ToList();
        }

        public async Task<Customer> GetCustomer(Guid CustomerID)
        {
            string sql = @"SELECT [CustomerID],[CustomerFirstName],[CustomerLastName],[IsActive] FROM [Customer] WHERE CustomerID =@CustomerID";
            return await Detail(CustomerID, sql);
        }

        public bool InsertCustomer(Customer ourCustomer)
        {
            int rowsAffected = this._db.Execute(@"INSERT Customer([CustomerFirstName],[CustomerLastName],[IsActive]) values (@CustomerFirstName, @CustomerLastName, @IsActive)",
                new { CustomerFirstName = ourCustomer.CustomerFirstName, CustomerLastName = ourCustomer.CustomerLastName, IsActive = true });

            if (rowsAffected > 0)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteCustomer(Guid CustomerID)
        {
            string sql = @"DELETE FROM[Customer] WHERE CustomerID = @CustomerID";
            return await Delete(CustomerID, sql);
        }

        public bool UpdateCustomer(Customer ourCustomer)
        {
            int rowsAffected = this._db.Execute(
                        "UPDATE [Customer] SET [CustomerFirstName] = @CustomerFirstName ,[CustomerLastName] = @CustomerLastName, [IsActive] = @IsActive WHERE CustomerID = " +
                        ourCustomer.CustomerID, ourCustomer);

            if (rowsAffected > 0)
            {
                return true;
            }

            return false;
        }
    }
}
