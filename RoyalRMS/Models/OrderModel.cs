using MongoDB.Bson;
using Realms;
using System.ComponentModel;


namespace RoyalRMS.Models
{
    public class OrderModel: RealmObject
    {
        [PrimaryKey]
        [MapTo("_id")]
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();

        [MapTo("ext_id")]
        [Required]
        public string OrderNumber { get; set; }

        [MapTo("customer")]
        [Required]
        public string Customer { get; set; }

        [MapTo("item")]
        [Required]
        public string Item { get; set; }

        [MapTo("quantity")]
        [DefaultValue(0)]
        public int Quantity { get; set; }

        [MapTo("bill_amt")]
        [DefaultValue(0.0)]
        public double BillAmount { get; set; }

    }
}
