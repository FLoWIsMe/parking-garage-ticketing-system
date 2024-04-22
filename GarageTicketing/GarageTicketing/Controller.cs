using GarageTicketing.Boundary;
using GarageTicketing.Entity;
using Microsoft.Data.Sqlite;

// For hashing 
using System.Security.Cryptography;
using System.Text;


namespace GarageTicketing.Controller
{
	public class Controller
	{
		public virtual void Validate() { }
		public virtual void Authenticate() { }
	}
	public static class OurHash
	{
		public static string ComputeHash(string aPassword)
		{
			using (var sha256 = SHA256.Create())
			{
				var data = sha256.ComputeHash(Encoding.UTF8.GetBytes(aPassword));
				var hashedPassword = BitConverter.ToString(data).Replace("-", "");
				return hashedPassword;
			}
		}
	}

	public static class DBConnector
	{
		private const string DataString = @"Data Source=..\..\..\GarageTicketing.db";

		public static void InitializeDB()
		{
			CreateDB();
			PopulateDB();
		}

		private static void CreateDB()
		{
			using (var conn = new SqliteConnection(DataString))
			using (var cmnd = conn.CreateCommand())
			{
				conn.Open();
				cmnd.CommandText = @"CREATE TABLE IF NOT EXISTS Account (
					Id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
					Type TEXT NOT NULL,
					Name TEXT NOT NULL,
					Pass TEXT NOT NULL
				);";
				cmnd.ExecuteNonQuery();
				cmnd.CommandText = @"CREATE TABLE IF NOT EXISTS Spot (
					Index INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
					Time DATETIME NOT NULL,
					User INTEGER NOT NULL,
					FOREIGN KEY(User) REFERENCES Account(Id)
				);";
				cmnd.ExecuteNonQuery();
				cmnd.CommandText = @"CREATE TABLE IF NOT EXISTS UserLog (
					LoginId INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
					Date DATETIME NOT NULL,
					Time DATETIME NOT NULL,
					Type INTEGER NOT NULL,
					AccountId INTEGER NOT NULL,
					FOREIGN KEY(AccountId) REFERENCES Account(Id)
				);";
				cmnd.ExecuteNonQuery();
			}
		}

		private static void PopulateDB()
		{
			using (var conn = new SqliteConnection(DataString))
			using (var cmnd = conn.CreateCommand())
			{
				conn.Open();
				var passwordHash = OurHash.ComputeHash("password");
				cmnd.CommandText = @"INSERT INTO Account (Type, Name, Pass) VALUES (@type, @name, @pass)";
				cmnd.Parameters.AddWithValue("@type", "admin");
				cmnd.Parameters.AddWithValue("@name", "admin");
				cmnd.Parameters.AddWithValue("@pass", passwordHash);
				cmnd.ExecuteNonQuery();
			}
		}

		public static Account GetAccount(string username, string password)
		{
			using (var conn = new SqliteConnection(DataString))
			using (var cmnd = conn.CreateCommand())
			{
				conn.Open();
				cmnd.CommandText = @"SELECT Type, User, Pass, Id FROM Account WHERE User = @username AND Pass = @password";
				cmnd.Parameters.AddWithValue("@username", username);
				cmnd.Parameters.AddWithValue("@password", OurHash.ComputeHash(password));
				using (var reader = cmnd.ExecuteReader())
				{
					if (reader.Read())
					{
						var account = new Account(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3));
						return account;
					}
				}
			}

			return new Account("", "", "", 0);
		}

		public static Spot GetSpot(int index)
		{
			using (var conn = new SqliteConnection(DataString))
			using (var cmnd = conn.CreateCommand())
			{
				conn.Open();
				cmnd.CommandText = @"SELECT Time, User, Index FROM Spot WHERE Index = @index";
				cmnd.Parameters.AddWithValue("@index", index);
				using (var reader = cmnd.ExecuteReader())
				{
					if (reader.Read())
					{
						var spot = new Spot(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2));
						return spot;
					}
				}
			}

			return null;
		}

		public static void SaveLogin(int accountID)
		{
			using (var conn = new SqliteConnection(DataString))
			using (var cmnd = conn.CreateCommand())
			{
				conn.Open();
				cmnd.CommandText = @"INSERT INTO UserLog (Date, Time, Type, AccountId) VALUES (@date, @time, 0, @accountId)";
				cmnd.Parameters.AddWithValue("@date", DateTime.Today);
				cmnd.Parameters.AddWithValue("@time", DateTime.Now);
				cmnd.Parameters.AddWithValue("@accountId", accountID);
				cmnd.ExecuteNonQuery();
			}
		}

		public static void RecordLogout(int accountID)
		{
			using (var conn = new SqliteConnection(DataString))
			using (var cmnd = conn.CreateCommand())
			{
				conn.Open();
				cmnd.CommandText = @"INSERT INTO UserLog (Date, Time, Type, AccountId) VALUES (@date, @time, 1, @accountId)";
				cmnd.Parameters.AddWithValue("@date", DateTime.Today);
				cmnd.Parameters.AddWithValue("@time", DateTime.Now);
				cmnd.Parameters.AddWithValue("@accountId", accountID);
				cmnd.ExecuteNonQuery();
			}
		}
	}

	public static class StartController
	{
		public static void Initialize()
		{
			DBConnector.InitializeDB();
			LoginForm loginForm = new LoginForm();
			Application.Run(loginForm);
		}
	}
}

