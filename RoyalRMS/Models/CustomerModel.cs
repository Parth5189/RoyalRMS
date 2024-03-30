using MongoDB.Bson;
using Realms;

namespace RoyalRMS.Models
{
    public class CustomerModel : RealmObject
    {
        [PrimaryKey]
        [MapTo("_id")]
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();

        [MapTo("name")]
        [Required]
        public string Name { get; set; }

        [MapTo("email")]
        [Required]
        public string Email { get; set; }

        [MapTo("phone")]
        [Required]
        public string Phone { get; set; }

        [MapTo("password")]
        [Required]
        public string Password { get; set; }

    }
}
