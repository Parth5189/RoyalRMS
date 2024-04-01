using MongoDB.Bson;
using Realms;
using System.ComponentModel;

namespace RoyalRMS.Models
{
    public class RestaurantModel: RealmObject
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

        [MapTo("location")]
        [DefaultValue("")]
        public string Location { get; set; }

        //[MapTo("menu")]
        //public string[] Menu { get; set; } = [];

        //[MapTo("service_types")]
        //public string[] ServiceTypes { get; set; } = [];
    }
}
