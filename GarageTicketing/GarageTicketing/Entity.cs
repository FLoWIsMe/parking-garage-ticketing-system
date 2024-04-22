namespace GarageTicketing.Entity
{
    public class Account
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Type { get; set; }
        public int Id { get; set; }

        public Account(string username, string passwordHash, string type, int id)
        {
            Username = username;
            PasswordHash = passwordHash;
            Type = type;
            Id = id;
        }
    }

    public class Spot
    {
        public DateTime Time { get; set; }
        public int User { get; set; }
        public int Index { get; set; }

        public Spot(DateTime time, int user, int index)
        {
            Time = time;
            User = user;
            Index = index;
        }
    }
    public class Spots
    {
        public Spot[] SpotsArray { get; set; }

        public Spots(Spot[] spotsArray)
        {
            SpotsArray = spotsArray;
        }
    }
}


