using GarageTicketing.Boundary;
using GarageTicketing.Entity;
using Microsoft.Data.Sqlite;

// For hashing 
using System.Security.Cryptography;
using System.Security.Principal;
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
			if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
				throw new ArgumentException("Username and password cannot be null or whitespace.");

			try
			{
				using (var conn = new SqliteConnection(DataString))
				{
					conn.Open();
					using (var cmnd = conn.CreateCommand())
					{
						cmnd.CommandText = @"SELECT Type, Name, Pass, Id FROM Account WHERE Name = @username AND Pass = @passwordHash";
						cmnd.Parameters.AddWithValue("@username", username);
						cmnd.Parameters.AddWithValue("@passwordHash", OurHash.ComputeHash(password));

						using (var reader = cmnd.ExecuteReader())
						{
							if (reader.Read())
							{
								var account = new Account(
									reader.GetString(1), // Username
									reader.GetString(2), // PasswordHash
									reader.GetString(0), // Type
									reader.GetInt32(3)   // Id
								);
								return account;
							}
						}
					}
				}
			}
			catch (SqliteException ex)
			{
				// Log the exception details
				// Consider rethrowing the exception or handling it as per your error handling policy
				throw; // Rethrow the exception after logging it if you want calling code to handle it
			}

			// Account not found or an error occurred
			return null;
		}

		public static bool SetAccount(string username, string password, string type)
		{
			if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(type))
				throw new ArgumentException("Username, password, and type cannot be null or whitespace.");

			try
			{
				using (var conn = new SqliteConnection(DataString))
				{
					conn.Open();
					using (var cmnd = conn.CreateCommand())
					{
						cmnd.CommandText = @"UPDATE Account SET Pass = @passwordHash, Type = @type WHERE Name = @username";
						cmnd.Parameters.AddWithValue("@username", username);
						cmnd.Parameters.AddWithValue("@passwordHash", OurHash.ComputeHash(password));
						cmnd.Parameters.AddWithValue("@type", type);

						int affectedRows = cmnd.ExecuteNonQuery();

						// If the number of affected rows is greater than 0, the update was successful.
						return affectedRows > 0;
					}
				}
			}
			catch (SqliteException ex)
			{
				// Log the exception details
				// Consider rethrowing the exception or handling it as per your error handling policy
				throw; // Rethrow the exception after logging it if you want calling code to handle it
			}
		}

		public static Spot GetSpot(int index)
		{
			try
			{
				using var conn = new SqliteConnection(DataString);
				conn.Open();

				using var cmnd = conn.CreateCommand();
				cmnd.CommandText = @"SELECT Time, User, Index FROM Spot WHERE Index = @index";
				cmnd.Parameters.AddWithValue("@index", index);

				using var reader = cmnd.ExecuteReader();
				if (reader.Read())
				{
					// Ensure the data types read from the database match what is expected for the Spot constructor.
					DateTime time = reader.GetDateTime(0);
					int user = reader.GetInt32(1);
					int indexValue = reader.GetInt32(2);

					var spot = new Spot(time, user, indexValue);
					return spot;
				}
			}
			catch (SqliteException ex)
			{
				// Log the exception details
				// Consider rethrowing the exception or handling it as per your error handling policy
				// Example: Log.Error(ex, "Error getting spot with index {index}", index);
				throw; // Rethrow the exception after logging it if you want calling code to handle it
			}

			// Spot not found
			return null;
		}

		public static bool SetSpot(int index, DateTime newTime, int newUser)
		{
			try
			{
				using var conn = new SqliteConnection(DataString);
				conn.Open();

				using var cmnd = conn.CreateCommand();
				cmnd.CommandText = @"UPDATE Spot SET Time = @newTime, User = @newUser WHERE Index = @index";
				cmnd.Parameters.AddWithValue("@newTime", newTime);
				cmnd.Parameters.AddWithValue("@newUser", newUser);
				cmnd.Parameters.AddWithValue("@index", index);

				int affectedRows = cmnd.ExecuteNonQuery();
				return affectedRows > 0; // Returns true if the spot was updated successfully
			}
			catch (SqliteException ex)
			{
				// Log the exception details
				// Example: Log.Error(ex, "Error setting spot with index {index}", index);
				throw; // Rethrow the exception after logging it if you want calling code to handle it
			}
		}

		public static List<Spot> GetSpots()
		{
			var spots = new List<Spot>();

			try
			{
				using var conn = new SqliteConnection(DataString);
				conn.Open();

				using var cmnd = conn.CreateCommand();
				cmnd.CommandText = @"SELECT Time, User, Index FROM Spot";

				using var reader = cmnd.ExecuteReader();
				while (reader.Read())
				{
					// Ensure the data types read from the database match what is expected for the Spot constructor.
					DateTime time = reader.GetDateTime(0);
					int user = reader.GetInt32(1);
					int index = reader.GetInt32(2);

					var spot = new Spot(time, user, index);
					spots.Add(spot);
				}
			}
			catch (SqliteException ex)
			{
				// Log the exception details
				// Example: Log.Error(ex, "Error retrieving spots from the database");
				throw; // Rethrow the exception after logging it if you want calling code to handle it
			}

			return spots;
		}

		public static Spot SaveSpot(int index, DateTime time, int user)
		{
			try
			{
				using var conn = new SqliteConnection(DataString);
				conn.Open();

				using var cmnd = conn.CreateCommand();
				cmnd.CommandText = @"INSERT OR REPLACE INTO Spot (Time, User, Index) VALUES (@time, @user, @index)";

				// Use the more secure Add method with a specific DbType to ensure correct type handling.
				cmnd.Parameters.AddWithValue("@time", time);
				cmnd.Parameters.AddWithValue("@user", user);
				cmnd.Parameters.AddWithValue("@index", index);
				cmnd.ExecuteNonQuery();

				// Retrieve and return the newly saved or updated spot.
				return GetSpot(index);
			}
			catch (SqliteException ex)
			{
				// Log the exception details
				// Example: Log.Error(ex, "Error saving spot with index {index}", index);
				throw; // Rethrow the exception after logging it if you want calling code to handle it
			}
		}

	public class LoginControl : Controller
	{
		public static bool login(string username, string password)
		{
			// Following figure 2.10 and 2.11
			bool isValid = validateInput(username, password);

			// Make sure we have valid input
			if (isValid)
			{
				// Hash the password given
				string hashedPassword = OurHash.ComputeHash(password);
				Account anAccount = DBConnector.GetAccount(username, hashedPassword);

				// Check their password
				bool isAuth = Authenticate(anAccount);

				if (isAuth)
				{
					// Figure 2.10
					UserLogService.SaveLogin(anAccount.Id);
					List<Spot> myList = DBConnector.GetSpots();

					// 0 is Spoteer
					if (anAccount.Type == "admin")
					{
						AdminMenu myMenu = new AdminMenu(myList, anAccount.Id);
						myMenu.Show();
						return true;
					}
					else if (anAccount.Type == "customer")
					{
						CustomerMenu myMenu = new CustomerMenu(anAccount.Id, myList);
						myMenu.Show();
						return true;
					}
					else
					{
						return false; // Final case for Roles
					}
				}
				else
				{
					return false; // Final case for Auth 
				}
			}
			else
			{
				return false; // Final case for Valid
			}
		}


		public class UserLogService
		{
			// This private method abstracts the common insert logic
			private static void InsertUserLog(int accountID, int type)
			{
				try
				{
					using var conn = new SqliteConnection(DataString);
					conn.Open();

					using var cmnd = conn.CreateCommand();
					cmnd.CommandText = @"INSERT INTO UserLog (Date, Time, Type, AccountId) VALUES (@date, @time, @type, @accountId)";

					cmnd.Parameters.AddWithValue("@date", DateTime.Today);
					cmnd.Parameters.AddWithValue("@time", DateTime.Now);
					cmnd.Parameters.AddWithValue("@type", type);
					cmnd.Parameters.AddWithValue("@accountId", accountID);

					cmnd.ExecuteNonQuery();
				}
				catch (SqliteException ex)
				{
					// Log the exception details
					// Example: Log.Error(ex, "Error recording user log with account ID {accountID}", accountID);
					throw; // Rethrow the exception after logging it
				}
			}

			public static void SaveLogin(int accountID)
			{
				InsertUserLog(accountID, 0); // Type 0 for login
			}

			public static void RecordLogout(int accountID)
			{
				InsertUserLog(accountID, 1); // Type 1 for logout
			}
		}


		public class SpotControl : Controller
		{
			public static ClaimSpotMenu CreateMenu { get; set; }
			public static void SpotMenu(int accountID)
			{
				CreateMenu = new ClaimSpotMenu(accountID);
				CreateMenu.Show();
			}

			public static bool submit(int userID, DateTime time, int index)
			{
				// Determine if our Spot is valid
				bool isValid = validate(userID, time, index);

				// If so, Follow Figure 2.13 CreateSpot Success
				if (isValid)
				{
					// Add it to the database 
					DBConnector.SaveSpot(index, time, userID);

					// Get a new set of Spots and open the Spoteer menu
					List<Spot> newList = DBConnector.GetSpots();

					SpoteerMenu SpotMenu = new SpoteerMenu(anSpot.owner);
					SpotMenu.formatSpots(newList);

					SpotMenu.Show();

					// Return so the CreateSpotMenu will close
					return true;
				}
				// Otherwise follow Figure 2.14 CreateAuctioin Invalid
				else return false;
			}

			public static bool validate(int userID, DateTime time, int index)
			{
				// Do some error checking and input validation
				if (userID < 0 || index < 0)
				{
					return false;
				}

				if (time < DateTime.Now)
				{
					return false;
				}

				return true;
				// We are using paramertized SQL so we don't need to do
				// a bunch of crazy regex stuff here... 
			}
		}

		public class ClaimControl : Controller
		{
			public static void select(int SpotID, int accountID)
			{
				// Following Figure 2.12:
				// Get the Spot from the database
				Spot anSpot = DBConnector.GetSpot(SpotID);

				// Create the EditClaimMenu and display it
				EditClaimMenu aEditClaimMenu = new EditClaimMenu(accountID);
				aEditClaimMenu.Show();
			}
			public static void submit(int index, DateTime time, int accountID)
			{
				DBConnector.SaveSpot(index, time, accountID);

				List<Spot> newList = DBConnector.GetSpots();

				AdminMenu aAdminMenu = new AdminMenu(newList, accountID);
				aAdminMenu.Show();
			}
		}

		public class StartController : Controller
		{
			public static void Initialize()
			{
				// Following Figure 2.9: startup
				DBConnector.InitializeDB();

				LoginForm myLogin = new LoginForm();

				Application.Run(myLogin);
			}
		}

		public static bool validateInput(string username, string password)
		{
			// Do some input vallidation... Database with paramaterized queires 
			// takes care of most of this 

			if (username == "" || password == "")
			{
				return false;
			}
			return true;
		}
		public static bool Authenticate(Account anAccount)
		{
			// The database queires for username and password.
			// Returns account with ID of 0 if username or password is wrong. 
			if (anAccount.Id == 0)
				return false;
			else
				return true;
		}
	}

	public class LogoutControl : Controller
	{
		public static void logout(int accountID)
		{
			// Following Figure 2.15 
			DBConnector.RecordLogout(accountID);

			LoginForm LoginForm = new LoginForm();
			LoginForm.Show();
		}
	}
}

