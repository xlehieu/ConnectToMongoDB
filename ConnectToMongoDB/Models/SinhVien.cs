using MongoDB.Bson.Serialization.Attributes;


namespace ConnectToMongoDB.Models
{
    public class SinhVien
    {
        [BsonId]
        public Object _id { get; set; }
        public string MaSV { get; set; }
        public string TenSV { get; set; }
        public Nullable<System.DateTime> NgaySinh { get; set; }
        public string DiaChi { get; set; }

    }
}
