using System.Text.Json.Serialization;

namespace WebApiShop
{
    public class User
    {
        public int id { get; set; }
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }  
        public string? Password { get; set; }
    }

    public class ExistingUser
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}