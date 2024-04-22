namespace GarageTicketing.Entity
{
    public class Account
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Type { get; set; }
        public int Id { get; set; }
    }

    public class Spot
    {
        public string Time { get; set; }
        public int User { get; set; }
        public int Index { get; set; }
    }

    public class Spots
    {
        public Spot[] SpotsArray { get; set; }
    }
}
