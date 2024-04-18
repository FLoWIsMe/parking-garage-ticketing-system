namespace GoodsAuctionSystem.Entity
{
    public class Account
    {
        // Private Attributes
        private string _usn;
        private string _pass; 
        private string _name; 
        private int _role;
        private int _accNum;

        // constants for error checking
        private const int maxAccNum = 2147483647; 
        private const int minAccNum = 0; 

        private const int maxRole = 10;
        private const int minRole = 0; 

        // Public attributes
        public string username
        {
            get{ return _usn; }
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Username cannot be null"); 
                }
                else
                {
                    _usn = value; 
                }
            }
        }
        
        public string password
        {
            get{ return _pass; }
            set
            {
                // Enforce password policy here
                if (value == null)
                {
                    throw new NullReferenceException("Password cannot be null"); 
                }
                else
                {
                    _pass = value; 
                }
            }
        }

        public string name 
        {
            get{ return _name; }
            set
            { 
                if (value == null)
                {
                    throw new NullReferenceException("Name cannot be null"); 
                }
                else
                {
                    _name = value;  
                }
            }
        }

        public int role
        {
            get{ return _role; }
            set
            {   
                if (value < minRole || value > maxRole)
                {
                    throw new ArgumentException($"Role: {value} is out of range ({minRole}, {maxRole})"); 
                }
                else
                {
                    _role = value;
                }
            }
        }

        public int accountNumber
        {
            get{ return _accNum; }
            set
            {   

                if (value > maxRole || value < minRole)
                {
                    throw new ArgumentException($"AccountNumber: {value} is out of range ({minAccNum}, {maxAccNum})"); 
                }
                else
                {
                    _accNum = value;
                }
            }
        }

        

        // Empty constructor for Account
        public Account() {}

        // Populated constructor for Account
        public Account(string aUserName, string aPassword, string aName, int aRole, int aAccountNumber)
        {
            username = aUserName;
            password = aPassword;
            name = aName; 
            role = aRole;
            accountNumber = aAccountNumber; 
        }
    }

    public class Auction
    {

        // Private Attributes for Auction
        private string _name;
        private string _desc; 
        private int _auctionId; 
        private float _hightestBid;
        private int _owner; 

        // Constants for error checking 
        private const int maxID = 2147483647; 
        private const int minID = 0; 

        // Public Attributes for Auction
        public bool condition { get; set; }
        
        public string name
        {
            get { return _name; }
            set 
            {
                if (value == null)
                {
                    throw new NullReferenceException("Name cannot be null"); 
                }
                else
                {
                    _name = value; 
                }
            }
        }

        public string description
        {
            get { return _desc; }
            set 
            {
                if (value == null)
                {
                    throw new NullReferenceException("Description cannot be null"); 
                }
                else
                {
                    _desc = value; 
                }
            }
        }

        public int auctionId 
        {
            get { return _auctionId; }
            set 
            {
                if (value > maxID || value < minID)
                {
                    throw new ArgumentException($"AuctionID: {value} is out of range ({minID}, {maxID})");
                }
                else
                {
                    _auctionId = value; 
                }
            }
        }

        public float hightestBid
        {
            get { return _hightestBid; }
            set 
            {
                if (value <= 0)
                {
                    throw new NullReferenceException("Highest Bid cannot be 0 or negative."); 
                }
                else if (value > _hightestBid)
                {
                    _hightestBid = value; 
                }
                else 
                {
                    throw new ArgumentException($"Highest Bid: {value} is not greater than highest bid: {hightestBid}."); 
                }
            }
        }
        
        public int owner
        {
            get { return _owner; }
            set 
            {
                if (value == null)
                {
                    throw new NullReferenceException("Owner cannot be null"); 
                }
                else
                {
                    _owner = value; 
                }
            }
        }

        // Empty constructor for Auction
        public Auction() {}

        // Populated constructor for Auction
        public Auction (string aName, string aDescription, bool aCondition, int aAuctionId, float aHighestBid, int OwnerAccountID)
        {
            name = aName;
            description = aDescription; 
            condition = aCondition; 
            auctionId = aAuctionId; 
            hightestBid = aHighestBid; 
            owner = OwnerAccountID;
        } 
    }
    
    public class Bid
    {
        
        //bid privates
        private int _bidId;
        private float _bidAmount;
        private int _bidder;

        //constants
        private const int maxID = 2147483647;
        private const int minID = 0;

        //publics
        public int bidId
        {
            get { return _bidId; }
            set
            {
                if (value > maxID || value < minID)
                {
                    throw new ArgumentException($"BidID: {value} is out of range ({minID}, {maxID})");
                }
                else
                {
                    _bidId = value;
                }
            }
        }

        public float bidAmount
        {
            get { return _bidAmount; }
            set
            {
                if (value < 0)
                { 
                    throw new ArgumentException($"BidAmount: {value} must be greater than 0");
                }
                else
                {
                    _bidAmount = value;
                }
            }
        }

        public int bidder
        {
            get { return _bidder; }
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Bidder cannot be negative."); 
                }
                else
                {
                    _bidder = value;
                }
            }
        }

        //empty constructor
        public Bid() {}

        //populated constructor
        public Bid(int aBidId, float aBidAmount, int aBidder)
        {
            bidId = aBidId;
            bidAmount = aBidAmount;
            bidder = aBidder;
        }
    }
}
