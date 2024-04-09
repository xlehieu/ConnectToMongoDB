using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ConnectToMongoDB.Models;
using MongoDB.Driver;

namespace ConnectToMongoDB.Controllers
{
    public class GiangVienController : Controller
    {
        // GET: GiangVienController
        public ActionResult Index()
        {
            MongoDBSetings.ConnectToMongoService();
            MongoDBSetings.giangvien_colection = MongoDBSetings.database.GetCollection<GiangVien>("giangvien");
            var filter = Builders<GiangVien>.Filter.Ne("_id", "");
            var result = MongoDBSetings.giangvien_colection.Find(filter).ToList();
            return View(result);
        }

        // GET: GiangVienController/Details/5
        public ActionResult Details(string id)
        {
            MongoDBSetings.ConnectToMongoService();
            MongoDBSetings.giangvien_colection = 
                MongoDBSetings.database.GetCollection<GiangVien>("giangvien");
            var filter = Builders<GiangVien>.Filter.Eq("_id", id);
            Console.WriteLine("Fillter: "+filter.ToString());
            Console.WriteLine("Id: "+id);
            var result = MongoDBSetings.giangvien_colection.Find(filter).SingleOrDefault();
            return View(result);
        }
        private static Random random = new Random();
        private object GenerateRandomId(int v)
        {
            string strarray = "abcdefghijklmnopqrstuvwxyz123456789";
            return new string(Enumerable.Repeat(strarray, v).Select(s => s[random.Next(s.Length)]).ToArray());
        }
        // GET: GiangVienController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GiangVienController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                MongoDBSetings.ConnectToMongoService();
                MongoDBSetings.giangvien_colection = MongoDBSetings.database.GetCollection<GiangVien>("giangvien");
                Object id = GenerateRandomId(24);
                string dateString = collection["NgaySinh"].ToString();
                DateTime dateTime = DateTime.Parse(dateString);
                MongoDBSetings.giangvien_colection.InsertOneAsync(new GiangVien { 
                    _id = id,
                     MaGV = collection["MaGV"].ToString(),
                    TenGV = collection["TenGV"].ToString(),
                    NgaySinh = dateTime,
                    SoDienThoai = collection["SoDienThoai"].ToString(),
                    DiaChi = collection["DiaChi"].ToString()
                });
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GiangVienController/Edit/5
        public ActionResult Edit(string id)
        {
            MongoDBSetings.ConnectToMongoService();
            MongoDBSetings.giangvien_colection = MongoDBSetings.database.GetCollection<GiangVien>("giangvien");
            var filter = Builders<GiangVien>.Filter.Eq("_id", id);
            var result = MongoDBSetings.giangvien_colection.Find(filter).SingleOrDefault();
            return View(result);
        }

        // POST: GiangVienController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, IFormCollection collection)
        {
            try
            {
                MongoDBSetings.ConnectToMongoService();
                MongoDBSetings.giangvien_colection = MongoDBSetings.database.GetCollection<GiangVien>("giangvien");
                var filter = Builders<GiangVien>.Filter.Eq("_id", id);
                string dateString = collection["NgaySinh"].ToString();
                DateTime dateTime = DateTime.Parse(dateString);
                var update = Builders<GiangVien>.Update.Set("MaGV", collection["MaGV"])
                    .Set("TenGV", collection["TenGV"]).Set("NgaySinh", dateTime).Set("SoDienThoai", collection["SoDienThoai"])
                    .Set("DiaChi", collection["DiaChi"]);
                var result = MongoDBSetings.giangvien_colection.UpdateOneAsync(filter, update);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GiangVienController/Delete/5
        public ActionResult Delete(string id)
        {
            MongoDBSetings.ConnectToMongoService();
            MongoDBSetings.giangvien_colection = MongoDBSetings.database.GetCollection<GiangVien>("giangvien");
            var filter = Builders<GiangVien>.Filter.Eq("_id", id);
            var result = MongoDBSetings.giangvien_colection.Find(filter).SingleOrDefault();
            return View(result);
        }

        // POST: GiangVienController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            try
            {
                MongoDBSetings.ConnectToMongoService();
                MongoDBSetings.giangvien_colection = MongoDBSetings.database.GetCollection<GiangVien>("giangvien");
                var filter = Builders<GiangVien>.Filter.Eq("_id", id);
                var result = MongoDBSetings.giangvien_colection.DeleteOneAsync(filter);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
