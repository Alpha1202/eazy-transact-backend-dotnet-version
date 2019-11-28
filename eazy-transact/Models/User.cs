using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace eazy_transact.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        public int AccountBalance { get; set; }

        public int Pin { get; set; }    

        public string OtpToken { get; set; }

        public string Secret { get; set; }

        
    }
}