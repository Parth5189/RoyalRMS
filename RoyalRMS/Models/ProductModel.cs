using MongoDB.Bson;
using Realms;
using System.ComponentModel;


namespace RoyalRMS.Models
{
    public class ProductModel: RealmObject
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

        [MapTo("price")]
        [DefaultValue(0.0)]
        public double Price { get; set; }

        [MapTo("stock_total")]
        [DefaultValue(0)]
        public int QuantityTotal { get; set; }

        [MapTo("stock_left")]
        [DefaultValue(0)]
        public int QuantityLeft { get; set; }
    }
}
