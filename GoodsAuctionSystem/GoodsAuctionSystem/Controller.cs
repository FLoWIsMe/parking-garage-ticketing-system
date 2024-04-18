using GoodsAuctionSystem.Boundary;
using GoodsAuctionSystem.Entity;
using Microsoft.Data.Sqlite;

// For hashing 
using System.Security.Cryptography;
using System.Text;


namespace GoodsAuctionSystem.Controller {

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
			@"data source = ..\..\..\GoodsAuctionSys.db";

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
				DROP TABLE IF EXISTS BID;
				DROP TABLE IF EXISTS AUCTION;
				DROP TABLE IF EXISTS USERLOG;
				DROP TABLE IF EXISTS ACCOUNT;
			";
			cmnd.ExecuteNonQuery();
			cmnd.CommandText = @"
				CREATE TABLE ACCOUNT (
				accountID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
				role INTEGER NOT NULL,
				name TEXT NOT NULL,
				user TEXT NOT NULL,
				password TEXT NOT NULL
			);";
			cmnd.ExecuteNonQuery();
			cmnd.CommandText = @"
				CREATE TABLE USERLOG (
				loginID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
				date DATETIME NOT NULL,
				time DATETIME NOT NULL,
				type INTEGER NOT NULL,
				accountID INTEGER NOT NULL,
				FOREIGN KEY(accountID) REFERENCES ACCOUNT(accountID)
			);";
			cmnd.ExecuteNonQuery();
			cmnd.CommandText = @"
				CREATE TABLE AUCTION (
				auctionID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
				startingPrice INTEGER NOT NULL,
				name TEXT NOT NULL,
				condition BOOL NOT NULL,
				currentPrice INTEGER NOT NULL,
				description TEXT NOT NULL,
				accountID INTEGER NOT NULL,
				FOREIGN KEY(accountID) REFERENCES ACCOUNT(accountID)
			);";
			cmnd.ExecuteNonQuery();
			cmnd.CommandText = @"
				CREATE TABLE BID (
				bidID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
				bidValue INTEGER NOT NULL,
				auctionID INTEGER NOT NULL,
				accountID INTEGER NOT NULL,
				FOREIGN KEY(auctionID) REFERENCES AUCTION(auctionID),
				FOREIGN KEY(accountID) REFERENCES ACCOUNT(accountID)
			);";
			cmnd.ExecuteNonQuery();
			conn.Close();
		}

		static void populateDB() {
			SqliteConnection conn = new SqliteConnection(dataString);
			conn.Open();
			SqliteCommand cmnd = conn.CreateCommand();
			// ACCOUNT INSERTS

			string passHash = OurHash.computeHash("#GoPhysics!");
			
			cmnd.CommandText = $@"
				INSERT INTO ACCOUNT (role, name, user, password)
				VALUES (1, 'John', 'johnlikesrush', '{passHash}')";
			cmnd.ExecuteNonQuery();
			cmnd.CommandText = $@"
				INSERT INTO ACCOUNT (role, name, user, password)
				VALUES (1, 'David', 'davedude99', '{passHash}')";
			cmnd.ExecuteNonQuery();
			cmnd.CommandText = $@"
				INSERT INTO ACCOUNT (role, name, user, password)
				VALUES (1, 'Leon', 'PurposefulParrot', '{passHash}')";
			cmnd.ExecuteNonQuery();
			cmnd.CommandText = $@"
				INSERT INTO ACCOUNT (role, name, user, password)
				VALUES (1, 'Jim', 'xMarksTheSpot', '{passHash}')";
			cmnd.ExecuteNonQuery();
			cmnd.CommandText = $@"
				INSERT INTO ACCOUNT (role, name, user, password)
				VALUES (0, 'Krystal', 'shinelikeadiamond', '{passHash}')";
			cmnd.ExecuteNonQuery();
			cmnd.CommandText = $@"
				INSERT INTO ACCOUNT (role, name, user, password)
				VALUES (0, 'Lily', 'TeaAndCoffee123', '{passHash}')";
			cmnd.ExecuteNonQuery();
			cmnd.CommandText = $@"
				INSERT INTO ACCOUNT (role, name, user, password)
				VALUES (0, 'James', 'NoPikachu2', '{passHash}')";
			cmnd.ExecuteNonQuery();
			// AUCTION INSERTS
			// ASSUME 0 IS NEW AND 1 IS USED
			cmnd.CommandText = @"
				INSERT INTO AUCTION (startingPrice, name, condition, currentPrice, description, accountID)
				VALUES (10, 'Custom Birdhouse', 0, 10, 'A handmade birdhouse made from birch wood.', 2)";
			cmnd.ExecuteNonQuery();
			cmnd.CommandText = @"
				INSERT INTO AUCTION (startingPrice, name, condition, currentPrice, description, accountID)
				VALUES (50000, 'Rush Guitar', 1, 50000, 'The personal guitar of Alex Lifeson from the tour, Time Machine.', 1)";
			cmnd.ExecuteNonQuery();
			cmnd.CommandText = @"
				INSERT INTO AUCTION (startingPrice, name, condition, currentPrice, description, accountID)
				VALUES (2, 'Space Notebook', 0, 2, 'Notebook with a glittery space cover.', 3)";
			cmnd.ExecuteNonQuery();
			cmnd.CommandText = @"
				INSERT INTO AUCTION (startingPrice, name, condition, currentPrice, description, accountID)
				VALUES (10, 'Minecraft Shirt', 1, 10, 'Shirt with a zombie from Minecraft on it.', 3)";
			cmnd.ExecuteNonQuery();
            cmnd.CommandText = @"
				INSERT INTO AUCTION (startingPrice, name, condition, currentPrice, description, accountID)
				VALUES (30, 'Managed Switch', 1, 30, 'A switch that is managed from your network.', 4)";
            cmnd.ExecuteNonQuery();
            cmnd.CommandText = @"
				INSERT INTO AUCTION (startingPrice, name, condition, currentPrice, description, accountID)
				VALUES (10000, 'Iphone 16', 0, 10000, 'The brand new iphone 16!.', 1)";
            cmnd.ExecuteNonQuery();
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
				SELECT user, password, name, role, accountID
				FROM ACCOUNT as a
				WHERE a.user = $username
				AND a.password = $password;";
			cmnd.Parameters.AddWithValue("$username", username);
			cmnd.Parameters.AddWithValue("$password", password);
			cmnd.ExecuteNonQuery();
			SqliteDataReader dataReader = cmnd.ExecuteReader();

			string AccUser = "";
			string AccPass = "";
			string AccName = "";
			int AccRole = 0;
			int AccID = 0;

			while (dataReader.Read()) {
				AccUser = dataReader.GetString(0);
				AccPass = dataReader.GetString(1);
				AccName = dataReader.GetString(2);
				AccRole = dataReader.GetInt32(3);
				AccID = dataReader.GetInt32(4);
			}
			conn.Close();
			Account acc = new Account(
				AccUser,
				AccPass,
				AccName,
				AccRole,
				AccID
			);
			return acc;
		}

		public static Auction AddAuction(Auction auction) {
			var conn = new SqliteConnection(dataString);
			conn.Open();
			var cmnd = conn.CreateCommand();
			cmnd.CommandText = @"
				INSERT INTO AUCTION (startingPrice, name, condition, 
					currentPrice, description, accountID)
				VALUES ($startingPrice, $name, $condition, 
					$startingPrice, $description, $accountID);";
			cmnd.Parameters.AddWithValue("$startingPrice", auction.hightestBid);
			cmnd.Parameters.AddWithValue("$name", auction.name);
			cmnd.Parameters.AddWithValue("$condition", auction.condition);
			cmnd.Parameters.AddWithValue("$description", auction.description);
			cmnd.Parameters.AddWithValue("$accountID", auction.owner); // Changed from auction.owner.accountNumber to. auction.owner. 
			cmnd.ExecuteNonQuery();
			cmnd.CommandText = @"
				SELECT COUNT(accountID)
				FROM ACCOUNT";
			SqliteDataReader dataReader = cmnd.ExecuteReader();
			int count = 0;

			while (dataReader.Read()) {
				count = dataReader.GetInt32(0);
			}
			auction.auctionId = count;
			return auction;
		}

		public static Auction GetAuction(int auctionID) {
			// Returns an auction with an associated Account object
			// when given an auctionID
			var conn = new SqliteConnection(dataString);
			conn.Open();
			var cmnd = conn.CreateCommand();
			cmnd.CommandText = @"
				SELECT name, description, condition, 
				auctionID, currentPrice, accountID
				FROM AUCTION as a
				WHERE a.auctionID = $auctionID;";
			cmnd.Parameters.AddWithValue("$auctionID", auctionID);
			cmnd.ExecuteNonQuery();
			SqliteDataReader dataReader = cmnd.ExecuteReader();

			string AucName = "";
			string AucDesc = "";
			bool AucCond = false;
			int AucID = 0;
			float AucHB = 0;
			int AucOwner = 0;

			while (dataReader.Read()) {
				AucName = dataReader.GetString(0);
				AucDesc = dataReader.GetString(1);
				AucCond = dataReader.GetBoolean(2);
				AucID = dataReader.GetInt32(3);
				AucHB = dataReader.GetFloat(4);
				AucOwner = dataReader.GetInt32(5);
			}
			conn.Close();
			Auction auc = new Auction(
				AucName,
				AucDesc,
				AucCond,
				AucID,
				AucHB,
                AucOwner // Changed from getOwner(AucOwner) to AucOwner
            );
			return auc;
		}

		private static Account getOwner(int accountID) {
			var conn = new SqliteConnection(dataString);
			conn.Open();
			var cmnd = conn.CreateCommand();
			cmnd.CommandText = @"
				SELECT user, password, name, role
				FROM ACCOUNT as a
				WHERE a.accountID = $accountID;";
			cmnd.Parameters.AddWithValue("$accountID", accountID);
			cmnd.ExecuteNonQuery();
			SqliteDataReader dataReader = cmnd.ExecuteReader();

			string AccUser = "";
			string AccPass = "";
			string AccName = "";
			int AccRole = 0;

			while (dataReader.Read()) {
				AccUser = dataReader.GetString(0);
				AccPass = dataReader.GetString(1);
				AccName = dataReader.GetString(2);
				AccRole = dataReader.GetInt32(3);
			}
			conn.Close();
			Account acc = new Account(
				AccUser,
				AccPass,
				AccName,
				AccRole,
				accountID
			);
			return acc;
		}

		public static void SaveLogin(int AccountID) {
			// Saves when the user is logged in to the UserLog table
			// Login is 0
			saveLoginOrLogout(0, AccountID);
		}

		public static List<Auction> ListAuction() {
			// Returns a random list of 6 auctions.
			// Will return fewer if there are not 6 available
			var conn = new SqliteConnection(dataString);
			conn.Open();
			var cmnd = conn.CreateCommand();
			cmnd.CommandText = @"
				SELECT name, description, condition, 
				auctionID, currentPrice, accountID
				FROM AUCTION as a
				ORDER BY RANDOM() LIMIT 6";
			cmnd.ExecuteNonQuery();
			SqliteDataReader dataReader = cmnd.ExecuteReader();
			List<Auction> auctionList = new List<Auction>();
			string AucName;
			string AucDesc;
			bool AucCond;
			int AucID;
			float AucHB;
			int AucOwner;

			while (dataReader.Read()) {
				AucName = dataReader.GetString(0);
				AucDesc = dataReader.GetString(1);
				AucCond = dataReader.GetBoolean(2);
				AucID = dataReader.GetInt32(3);
				AucHB = dataReader.GetFloat(4);
				AucOwner = dataReader.GetInt32(5);
				Auction auc = new Auction(
					AucName,
					AucDesc,
					AucCond,
					AucID,
					AucHB,
                    AucOwner // Changed from getOwner(AucOwner) to AucOwner 
                );
				auctionList.Add(auc);
			}
			conn.Close();
			return auctionList;
		}

		public static void UpdateAuction(int accountID, int auctionID, float bidValue) {
			// Update an Auction
			var conn = new SqliteConnection(dataString);
			conn.Open();
			var cmnd = conn.CreateCommand();
			cmnd.CommandText = @"
				INSERT INTO BID(bidValue, auctionID, accountID)
				VALUES ($bidValue, $auctionID, $accountID)";
			cmnd.Parameters.AddWithValue("$bidValue", bidValue);
			cmnd.Parameters.AddWithValue("$auctionID", auctionID);
			cmnd.Parameters.AddWithValue("$accountID", accountID);
			cmnd.ExecuteNonQuery();
			cmnd.CommandText = @"
				UPDATE AUCTION
				SET currentPrice = $bidValue
				WHERE auctionID = $auctionID;";
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

	public class AuctionControl : Controller
	{
		public static CreateAuctionMenu CreateMenu { get; set; }
		public static void auctionMenu(int accountID)
		{
			CreateMenu = new CreateAuctionMenu(accountID);
			CreateMenu.Show(); 
		}

		public static bool submit(Auction anAuction)
		{
			// Determine if our auction is valid
			bool isValid = validate(anAuction);

			// If so, Follow Figure 2.13 CreateAuction Success
			if (isValid)
			{
				// Add it to the database 
				DBConnector.AddAuction(anAuction);

				// Get a new set of auctions and open the Auctioneer menu
				List<Auction> newList = DBConnector.ListAuction();

				AuctioneerMenu AuctionMenu = new AuctioneerMenu(anAuction.owner);
				AuctionMenu.formatAuctions(newList);
				
				AuctionMenu.Show();

				// Return so the CreateAuctionMenu will close
				return true;
			}
			// Otherwise follow Figure 2.14 CreateAuctioin Invalid
			else return false;
		}

		public static bool validate(Auction anAuction)
		{
			// Do some error checking and input validation
			if (anAuction.name == "" || anAuction.name == " ")
			{
				return false;
			}

			if (anAuction.description.Length > 200 || anAuction.description == "" || anAuction.description == " ")
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
		public static void select(int auctionID, int accountID)
		{
			// Following Figure 2.12:
			// Get the auction from the database
			Auction anAuction = DBConnector.GetAuction(auctionID);

			// Create the PlaceBidMenu and display it
			PlaceBidMenu aPlaceBidmenu = new PlaceBidMenu(anAuction, accountID);
			aPlaceBidmenu.Show();
		}
		public static void submit(int accountID, int  auctionID, float newHighestBid)
		{
            DBConnector.UpdateAuction(accountID, auctionID, newHighestBid);

            List<Auction> newList = DBConnector.ListAuction();

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
					DBConnector.SaveLogin(anAccount.accountNumber);
					List<Auction> myList = DBConnector.ListAuction();
					
					// 0 is Auctioneer
					if (anAccount.role == 0)
					{
                        AuctioneerMenu myMenu = new AuctioneerMenu(anAccount.accountNumber);
						myMenu.formatAuctions(myList);
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
