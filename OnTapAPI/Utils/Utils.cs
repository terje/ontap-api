using System;
using Microsoft.Data.Sqlite;

namespace OnTapAPI.Utils
{
    public static class Utils
    {
		public static void SetupDB()
		{
            /*
			string conString = ConfigurationManager.ConnectionStrings["sql_migrations"]
												   .ConnectionString;
			using (var con = new SqlConnection(conString))
			{
				// check if the migrations table exists, otherwise execute the first script (which creates that table)
				if (con.ExecuteScalar<int>(@"SELECT count(1) FROM sys.tables
                                            WHERE T.Name = 'migrationscripts'") == 0)
				{
					con.Execute(GetSql("20151204-1030-Init"));
					con.Execute(@"INSERT INTO MigrationScripts (Name, ExecutionDate) 
                                                VALUES (@Name, GETDATE())",
														new { Name = "20151204-1030-Init" });
				}

				// Get all scripts that have been executed from the database
				var executedScripts = con.Query<string>("SELECT Name FROM MigrationScripts");

				// Get all scripts from the filesystem
				Directory.GetFiles(HostingEnvironment.MapPath("/App_Data/Scripts/"))
						 // strip out the extensions
						 .Select(Path.GetFileNameWithoutExtension)
						 // filter the ones that have already been executed
						 .Where(fileName => !executedScripts.Contains(fileName))
						 // Order by the date in the filename
						 .OrderBy(fileName =>
							DateTime.ParseExact(fileName.Substring(0, 13), "yyyyMMdd-HHmm", null))
						 .ForEach(script =>
						 {
					 // Execute each on of the scripts
					 con.Execute(GetSql(script));
					 // record that it was executed in the migrationscripts table
					 con.Execute(@"INSERT INTO MigrationScripts (Name, ExecutionDate) 
                                                         VALUES (@Name, GETDATE())",
																 new { Name = script });
						 });
			}
			*/
		}

        /*
        static string GetSql(string fileName) =>
        File.ReadAllText(HostingEnvironment.MapPath($"/App_Data/Scripts/{fileName}.sql"));
        */
}
}
