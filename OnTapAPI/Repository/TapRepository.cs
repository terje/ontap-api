using System;
using Dapper;
using OnTapAPI.Models;
using System.Linq;
using Microsoft.Data.Sqlite;


using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace OnTapAPI.Repository
{
    public class TapRepository
    {
        private string connectionString;
        public TapRepository(IConfiguration configuration)
        {
            connectionString = $"Data Source={configuration.GetValue<string>("DB:File")}";
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqliteConnection(connectionString);
            }
        }

		public void Add(Tap tap)
		{
			using (IDbConnection dbConnection = Connection)
			{
				string sQuery = "INSERT INTO taps (kegId, position, flowId)"
								+ " VALUES(@kegIg, @position, @flowId)";
				dbConnection.Open();
				dbConnection.Execute(sQuery, tap);
			}
		}

		public IEnumerable<Tap> GetAll()
		{
			using (IDbConnection dbConnection = Connection)
			{
				dbConnection.Open();
				return dbConnection.Query<Tap>("SELECT * FROM Taps");
			}
		}

		public Tap GetByID(int id)
		{
			using (IDbConnection dbConnection = Connection)
			{
				string sQuery = "SELECT * FROM taps"
							   + " WHERE id = @Id";
				dbConnection.Open();
				return dbConnection.Query<Tap>(sQuery, new { Id = id }).FirstOrDefault();
			}
		}

		public void Delete(int id)
		{
			using (IDbConnection dbConnection = Connection)
			{
				string sQuery = "DELETE FROM Taps"
							 + " WHERE id = @Id";
				dbConnection.Open();
				dbConnection.Execute(sQuery, new { Id = id });
			}
		}

        public void Update(Tap tap)
		{
			using (IDbConnection dbConnection = Connection)
			{
				string sQuery = "UPDATE Products SET kegId = @kegId,"
							   + " position = @position, flowId = @flowId"
							   + " WHERE id = @id";
				dbConnection.Open();
				dbConnection.Query(sQuery, tap);
			}
		}
    }
}