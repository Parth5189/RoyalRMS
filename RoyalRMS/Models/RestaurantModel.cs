using MongoDB.Bson;
using Realms;
using System.ComponentModel;

namespace RoyalRMS.Models
{
    public class RestaurantModel : RealmObject
    {
        [PrimaryKey]
        [MapTo("_id")]
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();

        [MapTo("name")]
        [Required]
        public string Name { get; set; }

        [MapTo("description")]
        [DefaultValue("")]
        public string Description { get; set; }

        [MapTo("menu")]
        public IList<string> Menu { get; } 

        [MapTo("service_types")]
        public IList<string> ServiceTypes { get; }
    }
}
