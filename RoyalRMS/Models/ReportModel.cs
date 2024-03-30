using MongoDB.Bson;
using Realms;
using System.ComponentModel;

namespace RoyalRMS.Models
{

    public class ReportModel : RealmObject
    {
        [PrimaryKey]
        [MapTo("_id")]
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();

        [MapTo("title")]
        [Required]
        public string Title { get; set; }

        [MapTo("current")]
        [DefaultValue(0)]
        public int CurrentSales { get; set; }

        [MapTo("lastweek")]
        [DefaultValue(0)]
        public int LastWeekSales { get; set; }

        [MapTo("lastmonth")]
        [DefaultValue(0)]
        public int LastMonthSales { get; set; }
    }
}
