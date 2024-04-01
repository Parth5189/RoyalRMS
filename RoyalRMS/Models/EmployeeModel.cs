using MongoDB.Bson;
using Realms;
using System.ComponentModel;

namespace RoyalRMS.Models
{
    public class EmployeeModel : RealmObject
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

        [MapTo("position")]
        [Required]
        public string Position { get; set; }

        [MapTo("salary")]
        [DefaultValue(0.0)]
        public double Salary { get; set; }

        [MapTo("isPaid")]
        [DefaultValue(false)]
        public bool IsPaid { get; set; }
    }
}
