using MongoDB.Bson.Serialization.Attributes;

namespace ConnectToMongoDB.Models
{
    public class TaiKhoan
    {
        [BsonId]
        public Object _id { get; set; }
        public string TenDangNhap {  get; set; }
        public string MatKhau { get; set; }

    }
}
