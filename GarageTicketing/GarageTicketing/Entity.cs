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
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Username cannot be null or whitespace.", nameof(username));

            if (string.IsNullOrWhiteSpace(passwordHash))
                throw new ArgumentException("PasswordHash cannot be null or whitespace.", nameof(passwordHash));

            if (string.IsNullOrWhiteSpace(type))
                throw new ArgumentException("Type cannot be null or whitespace.", nameof(type));

            if (id < 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id cannot be negative.");

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
            if (user < 0)
                throw new ArgumentOutOfRangeException(nameof(user), "User cannot be negative.");

            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index), "Index cannot be negative.");

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
            if (spotsArray == null || spotsArray.Length == 0)
                throw new ArgumentException("SpotsArray cannot be null or empty.", nameof(spotsArray));

            SpotsArray = spotsArray;
        }
    }
}