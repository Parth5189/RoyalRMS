using MongoDB.Bson;
using Realms;
using System.ComponentModel;


namespace RoyalRMS.Models
{
    public class OrderModel : RealmObject
    {
        [PrimaryKey]
        [MapTo("_id")]
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();

        [MapTo("ext_id")]
        [Required]
        public string OrderNumber { get; set; }

        [MapTo("customer_name")]
        public CustomerModel Customer { get; set; }

        [MapTo("items")]
        public IDictionary<string, int> Items { get; }  // productname: quantity

        [MapTo("bill_amt")]
        [DefaultValue(0.0)]
        public double BillAmount { get; set; }

    }
}
