namespace GarageTicketing.Entity
{
    public class Account
    {
        private string _username;
        private string _passwordHash;
        private string _name;
        private int _type;
        private int _id;

        private const int MaxId = int.MaxValue;
        private const int MinId = 0;

        public string PasswordHash
        {
            get { return _passwordHash; }
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Password cannot be null");
                }
                _passwordHash = value;
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Name cannot be null");
                }
                _name = value;
            }
        }

        public int Type
        {
            get { return _type; }
            set
            {
                if (value < MinId || value > MaxId)
                {
                    throw new ArgumentException($"Role: {value} is out of range ({MinId}, {MaxId})");
                }
                _type = value;
            }
        }

        public int Id
        {
            get { return _id; }
            set
            {
                if (value < MinId || value > MaxId)
                {
                    throw new ArgumentException($"AccountNumber: {value} is out of range ({MinId}, {MaxId})");
                }
                _id = value;
            }
        }

        public Account() { }

        public Account(string username, string password, string name, int type, int id)
        {
            Username = username;
            PasswordHash = password;
            Name = name;
            Type = type;
            Id = id;
        }
    }

    public class Spot
    {
        private int _userID;
        private string _time;
        private int _index;

        private const int MaxId = int.MaxValue;
        private const int MinId = 0;

        public bool Condition { get; set; }

        public int UserID
        {
            get { return _userID; }
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException("User cannot be null");
                }
                _userID = value;
            }
        }

        public string Time
        {
            get { return _time; }
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Time cannot be null");
                }
                _time = value;
            }
        }

        public int Index
        {
            get { return _index; }
            set
            {
                if (value < MinId || value > MaxId)
                {
                    throw new ArgumentException($"Spot Index: {value} is out of range ({MinId}, {MaxId})");
                }
                _index = value;
            }
        }

        public Spot() { }

        public Spot(string time, Account user, int index)
        {
            Time = time;
            User = user;
            Index = index;
        }
    }

    public class Spots
    {
        private Spot[] _spots;

        public Spot[] Spots
        {
            get { return _spots; }
            set { _spots = value; }
        }

        public Spots() { }

        public Spots(Spot[] spots)
        {
            Spots = spots;
        }
    }
}