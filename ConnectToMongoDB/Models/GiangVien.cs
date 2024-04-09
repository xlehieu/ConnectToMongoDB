using MongoDB.Bson.Serialization.Attributes;

namespace ConnectToMongoDB.Models
{
    public class GiangVien
    {
        [BsonId]
        public Object _id { get; set; }
        public  string MaGV { get; set; }
        public string TenGV { get; set; }
        public Nullable<System.DateTime> NgaySinh { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; }
    }
}
