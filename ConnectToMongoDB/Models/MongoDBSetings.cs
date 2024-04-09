using MongoDB.Driver;

namespace ConnectToMongoDB.Models
{
    public class MongoDBSetings
    {
        public static IMongoClient client { get; set; }
        public static IMongoDatabase database { get; set; }
        public static string mongoConnection = "mongodb://localhost:27017";
        public static string mongoDatabase = "quanlysinhvien";

        public static IMongoCollection<Models.SinhVien> sinhvien_colecttion { get; set; }
        public static IMongoCollection<GiangVien> giangvien_colection { get; set; }
        public static IMongoCollection<MonHoc> monhoc_collection { get; set; }
        public static IMongoCollection<TaiKhoan> taikhoan_colection { get; set; }
        internal static void ConnectToMongoService()
        {
            try
            {
                client = new MongoClient(mongoConnection);
                database = client.GetDatabase(mongoDatabase);
            }
            catch (Exception) 
            {
                throw;
            }
        }
       
    }
}
