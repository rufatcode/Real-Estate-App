using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace RealEstate_API.DAL
{
	public class DataContext
	{
		private readonly IConfiguration _configuration;
		private readonly string _conectionSting;
		public DataContext(IConfiguration configuration)
		{
			_configuration = configuration;
			_conectionSting = _configuration.GetConnectionString("DefaultConnection");
		}
		public IDbConnection CreateConnection() => new SqlConnection(_conectionSting);

    }
}

