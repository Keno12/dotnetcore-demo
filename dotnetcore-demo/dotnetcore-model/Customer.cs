using System;

namespace dotnetcore_model
{
	public class Customer
	{
		public Guid CustomerID { get; set; }

		public string CustomerFirstName { get; set; }

		public string CustomerLastName { get; set; }

		public bool IsActive { get; set; }
	}
}
