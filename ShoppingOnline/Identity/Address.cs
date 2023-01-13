namespace ShoppingOnline.Services.Identity
{
    public class Address
    {
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zipcode { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}