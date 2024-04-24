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
						var spot = new Spot(reader.GetDateTime(0), reader.GetInt32(1), reader.GetInt32(2));
						return spot;
					}
				}
			}

			return null;
		}

		public static List<Spot> GetSpots()
		{
			using (var conn = new SqliteConnection(DataString))
			using (var cmnd = conn.CreateCommand())
			{
				conn.Open();
				cmnd.CommandText = @"SELECT Time, User, Index FROM Spot";
				using (var reader = cmnd.ExecuteReader())
				{
					var spots = new List<Spot>();
					while (reader.Read())
					{
						var spot = new Spot(reader.GetDateTime(0), reader.GetInt32(1), reader.GetInt32(2));
						spots.Add(spot);
					}
					return spots;
				}
			}
		}

		public static Spot SaveSpot(int index, DateTime time, int user)
		{
			using (var conn = new SqliteConnection(DataString))
			using (var cmnd = conn.CreateCommand())
			{
				conn.Open();
				cmnd.CommandText = @"INSERT OR REPLACE INTO Spot (Time, User, Index) VALUES (@time, @user, @index)";
				cmnd.Parameters.AddWithValue("@time", time);
				cmnd.Parameters.AddWithValue("@user", user);
				cmnd.Parameters.AddWithValue("@index", index);
				cmnd.ExecuteNonQuery();

				return GetSpot(index);
			}
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

				SpotMenu spotMenu = new SpotMenu(anSpot.owner);
				spotMenu.formatSpots(newList);

				spotMenu.Show();

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

			aAdminMenu = new AdminMenu(newList, accountID);
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
					DBConnector.SaveLogin(anAccount.Id);
					List<Spot> myList = DBConnector.GetSpots();

					// 0 is Spoteer
					if (anAccount.Type == "admin")
					{
						AdminMenu myMenu = new AdminMenu(anAccount.Id);
						myMenu.FormatSpots(myList);
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

