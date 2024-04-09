using MongoDB.Bson.Serialization.Attributes;

namespace ConnectToMongoDB.Models
{
    public class MonHoc
    {
        [BsonId]
        public Object _id { get; set; }
        public string MaMH { get; set; }
        public string TenMH { get; set; }
        public int SoTinChi { get; set; }
    }
}
