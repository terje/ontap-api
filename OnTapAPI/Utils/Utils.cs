using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;
using Dapper;

namespace OnTapAPI.Utils
{
    public static class DB
    {
        public static void SetupDB()
        {
            using (var con = GetSqliteConnection())
            {
                Int64 result = (Int64)con.ExecuteScalar("SELECT count() FROM sqlite_master where tbl_name = 'migrations'");
                if (result.Equals(0))
                {
                    con.Execute("CREATE TABLE IF NOT EXISTS 'migrations' (executiondate, name)");
					con.Execute(@"INSERT INTO migrations (executiondate, name) 
                                        VALUES (CAST((julianday('now') - 2440587.5)*86400000 AS INTEGER), @Name)",
												new { Name = "MigrationsTable" });
                }
                con.Close();
            }
        }

        public static void Migrate()
        {
            using (var con = GetSqliteConnection())
            {
				// Get all scripts that have been executed from the database
                var executedScripts = con.Query<string>("SELECT Name FROM migrations");

                // Get all scripts from the filesystem and remove scripts that have been run already
                var sqlScriptFiles = Directory.EnumerateFiles("DB/Migrations").Except(executedScripts);

                // Then run all migration scripts

                foreach (var file in sqlScriptFiles)
                {
                    try
                    {
                        con.Execute(File.ReadAllText(file));
						con.Execute(@"INSERT INTO migrations (executiondate, name) 
                                        VALUES (CAST((julianday('now') - 2440587.5)*86400000 AS INTEGER), @Name)",
												new { Name = file });
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"failed to migrate: {ex.Message}");
                        throw;
                    }
                }
            }
        }

		private static SqliteConnection GetSqliteConnection(bool open = true)
		{
            //Directory.CreateDirectory("DB");
			var connection = new SqliteConnection("Data Source=DB/ontap.sqlite3"); // :memory:
			if (open) connection.Open();
			return connection;
		}
    }
}