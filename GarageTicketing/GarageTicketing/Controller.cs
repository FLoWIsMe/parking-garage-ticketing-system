using GarageTicketing.Boundary;
using GarageTicketing.Entity;
using Microsoft.Data.Sqlite;

// For hashing 
using System.Security.Cryptography;
using System.Text;


namespace GarageTicketing.Controller {

	public class Controller {
		public virtual void validate() { }
		public virtual void authenticate() { }
	}
	public static class OurHash
	{
		public static string computeHash(string aPassword)
		{
            using (SHA256 sha256 = SHA256.Create())
            {
                // Get Hash 
                byte[] data = sha256.ComputeHash(Encoding.UTF8.GetBytes(aPassword));

                var sBuilder = new StringBuilder();
                // Format as hex
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                // return hex string
                string hashedPassword = sBuilder.ToString();

				return hashedPassword; 
            }
        }
	}

	public static class DBConnector {

		private const string dataString =
			@"data source = ..\..\..\GarageTicketing.db";

		public static void InitializeDB() {
			CreateDB();
			populateDB();
		}

		static void CreateDB() {
			var conn = new SqliteConnection(dataString);
			conn.Open();
			var cmnd = conn.CreateCommand();
			// DROP ORDER MATTERS!
			// MUST DROP TABLES THAT REFERENCE OTHER TABLES FIRST!
			cmnd.CommandText = @"
				CREATE TABLE ACCOUNT (
				id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
				type TEXT NOT NULL,
				name TEXT NOT NULL,
				pass TEXT NOT NULL
			);";
			cmnd.ExecuteNonQuery();
			cmnd.CommandText = @"
				CREATE TABLE SPOT (
				index INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
				time DATETIME NOT NULL,
				FOREIGN KEY(user) REFERENCES ACCOUNT(id)
			);";
			cmnd.ExecuteNonQuery();
			cmnd.CommandText = @"
				CREATE TABLE USERLOG (
				loginID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
				date DATETIME NOT NULL,
				time DATETIME NOT NULL,
				type INTEGER NOT NULL,
				accountID INTEGER NOT NULL,
				FOREIGN KEY(accountID) REFERENCES ACCOUNT(id)
			);";
			cmnd.ExecuteNonQuery();
			conn.Close();
		}

		static void populateDB() {
			SqliteConnection conn = new SqliteConnection(dataString);
			conn.Open();
			SqliteCommand cmnd = conn.CreateCommand();
			// ACCOUNT INSERTS
			string passHash = OurHash.computeHash("password");
			cmnd.CommandText = $@"
				INSERT INTO ACCOUNT (type, name, pass)
				VALUES ('admin', 'admin', '{passHash}')";
			cmnd.ExecuteNonQuery();
			cmnd.CommandText = $@"
				INSERT INTO ACCOUNT (type, name, pass)
				VALUES ('user', 'Bob', '{passHash}')";
			cmnd.ExecuteNonQuery();
			cmnd.CommandText = $@"
				INSERT INTO ACCOUNT (type, name, pass)
				VALUES ('user', 'Billy', '{passHash}')";
			cmnd.ExecuteNonQuery();
			cmnd.CommandText = $@"
				INSERT INTO ACCOUNT (type, name, pass)
				VALUES ('user', 'Benjamin', '{passHash}')";
			cmnd.ExecuteNonQuery();
			// SPOT INSERTS
			for (int i = 0; i < 8; i++) {
			cmnd.CommandText = @"
				INSERT INTO Spot (time, user)
				VALUES (NULL, NULL)";
			cmnd.ExecuteNonQuery();
			}
			conn.Close();
		}

		public static Account GetAccount(string username, string password) {
			// Returns a populated account object with database information if username
			// and password is correct. Otherwise, returns an empty Account object with an 
			// ID of 0. It is the only Account to have this property, so checking for a
			// false condition should always be done by checking the ID.
			var conn = new SqliteConnection(dataString);
			conn.Open();
			var cmnd = conn.CreateCommand();
			cmnd.CommandText = @"
				SELECT type, user, pass, id
				FROM ACCOUNT as a
				WHERE a.user = $username
				AND a.pass = $password;";
			cmnd.Parameters.AddWithValue("$username", username);
			cmnd.Parameters.AddWithValue("$password", password);
			cmnd.ExecuteNonQuery();
			SqliteDataReader dataReader = cmnd.ExecuteReader();

			string AccType = "";
			string AccName = "";
			string AccPass = "";
			int AccId = 0;

			while (dataReader.Read()) {
				AccType = dataReader.GetString(0);
				AccName = dataReader.GetString(1);
				AccPass = dataReader.GetString(2);
				AccId = dataReader.GetInt32(3);
			}
			conn.Close();
			Account account = new Account(
				AccType,
				AccPass,
				AccName,
				AccId
			);
			return account;
		}


		public static Spot GetSpot(int index) {
			// Returns an Spot with an associated Account object
			// when given an index
			var conn = new SqliteConnection(dataString);
			conn.Open();
			var cmnd = conn.CreateCommand();
			cmnd.CommandText = @"
				SELECT time, user, index, 
				FROM SPOT as a
				WHERE a.index = $index;";
			cmnd.Parameters.AddWithValue("$index", index);
			cmnd.ExecuteNonQuery();
			SqliteDataReader dataReader = cmnd.ExecuteReader();

			int SpotTime = 0;
			int SpotUser = 0;
			int SpotIndex = 0;

			while (dataReader.Read()) {
				SpotTime = dataReader.GetInt32(0);
				SpotUser = dataReader.GetInt32(1);
				SpotIndex = dataReader.GetInt32(2);
			}
			conn.Close();
			Spot spot = new Spot(
				SpotTime,
				SpotUser,
				SpotIndex
            );
			return spot;
		}

		public static void SaveLogin(int AccountID) {
			// Saves when the user is logged in to the UserLog table
			// Login is 0
			saveLoginOrLogout(0, AccountID);
		}

		public static List<Spot> ListSpots() {
			// Returns a random list of 6 Spots.
			// Will return fewer if there are not 6 available
			var conn = new SqliteConnection(dataString);
			conn.Open();
			var cmnd = conn.CreateCommand();
			cmnd.CommandText = @"
				SELECT time, user, index
				FROM SPOT";
			cmnd.ExecuteNonQuery();
			SqliteDataReader dataReader = cmnd.ExecuteReader();
			List<Spot> SpotList = new List<Spot>();
			int SpotTime;
			int SpotUser;
			int SpotIndex;

			while (dataReader.Read()) {
				SpotTime = dataReader.GetInt32(0);
				SpotUser = dataReader.GetInt32(1);
				SpotIndex = dataReader.GetInt32(2);
				Spot spot = new Spot(
					SpotTime,
					SpotUser,
					SpotIndex
                );
				SpotList.Add(spot);
			}
			conn.Close();
			return SpotList;
		}

		public static void UpdateSpot(int index, int time, int user) {
			// Update an Spot
			var conn = new SqliteConnection(dataString);
			conn.Open();
			var cmnd = conn.CreateCommand();
			cmnd.CommandText = @"
				UPDATE SPOT
				SET time = $time, user = $user
				WHERE index = $index;";
			cmnd.Parameters.AddWithValue("$time", time);
			cmnd.Parameters.AddWithValue("$user", user);
			cmnd.Parameters.AddWithValue("$index", index);
			cmnd.ExecuteNonQuery();
		}

		public static void RecordLogout(int accountID) {
			// Saves when the user is logged out to the UserLog table
			// Logout is 1
			saveLoginOrLogout(1, accountID);
		}

		private static void saveLoginOrLogout(int type, int accountID) {
			DateTime dateOnly = DateTime.Today;
			DateTime timeOnly = DateTime.Now;
			var conn = new SqliteConnection(dataString);
			conn.Open();
			var cmnd = conn.CreateCommand();
			cmnd.CommandText = @"
				INSERT INTO USERLOG (date, time, type, accountID)
				VALUES ($date, $time, $type, $accountID)";
			cmnd.Parameters.AddWithValue("$date", dateOnly);
			cmnd.Parameters.AddWithValue("$time", timeOnly);
			cmnd.Parameters.AddWithValue("$type", type);
			cmnd.Parameters.AddWithValue("$accountID", accountID);
			cmnd.ExecuteNonQuery();
		}
	}

	public class SpotControl : Controller
	{
		public static CreateSpotMenu CreateMenu { get; set; }
		public static void SpotMenu(int accountID)
		{
			CreateMenu = new CreateSpotMenu(accountID);
			CreateMenu.Show(); 
		}

		public static bool submit(Spot anSpot)
		{
			// Determine if our Spot is valid
			bool isValid = validate(anSpot);

			// If so, Follow Figure 2.13 CreateSpot Success
			if (isValid)
			{
				// Add it to the database 
				DBConnector.AddSpot(anSpot);

				// Get a new set of Spots and open the Spoteer menu
				List<Spot> newList = DBConnector.ListSpot();

				SpoteerMenu SpotMenu = new SpoteerMenu(anSpot.owner);
				SpotMenu.formatSpots(newList);
				
				SpotMenu.Show();

				// Return so the CreateSpotMenu will close
				return true;
			}
			// Otherwise follow Figure 2.14 Createspottioin Invalid
			else return false;
		}

		public static bool validate(Spot anSpot)
		{
			// Do some error checking and input validation
			if (anSpot.name == "" || anSpot.name == " ")
			{
				return false;
			}

			if (anSpot.description.Length > 200 || anSpot.description == "" || anSpot.description == " ")
			{
				return false;
			}

			return true;
			// We are using paramertized SQL so we don't need to do
			// a bunch of crazy regex stuff here... 
		}
	}

	public class BidController : Controller
	{
		public static void select(int SpotID, int accountID)
		{
			// Following Figure 2.12:
			// Get the Spot from the database
			Spot anSpot = DBConnector.GetSpot(SpotID);

			// Create the PlaceBidMenu and display it
			PlaceBidMenu aPlaceBidmenu = new PlaceBidMenu(anSpot, accountID);
			aPlaceBidmenu.Show();
		}
		public static void submit(int accountID, int  SpotID, float newHighestBid)
		{
            DBConnector.UpdateSpot(accountID, SpotID, newHighestBid);

            List<Spot> newList = DBConnector.ListSpot();

            BidderMenu aBidderMenu = new BidderMenu(accountID, newList);
			aBidderMenu.Show();
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
				string hashedPassword = OurHash.computeHash(password);
				Account anAccount = DBConnector.GetAccount(username, hashedPassword);

				// Check their password
				bool isAuth = Authenticate(anAccount);
				
				if (isAuth) 
				{
					// Figure 2.10
					DBConnector.SaveLogin(anAccount.Id);
					List<Spot> myList = DBConnector.ListSpots();
					
					// 0 is Spoteer
					if (anAccount.role == 0)
					{
                        SpoteerMenu myMenu = new SpoteerMenu(anAccount.accountNumber);
						myMenu.formatSpots(myList);
						myMenu.Show();
						return true; 
					}
					else if (anAccount.role == 1)
					{
						BidderMenu myMenu = new BidderMenu(anAccount.accountNumber, myList);
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
			if (anAccount.accountNumber == 0) 
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
