using ConnectToMongoDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using MongoDB.Driver;
using System.Buffers.Text;

namespace ConnectToMongoDB.Controllers
{
    public class SinhVienController : Controller
    {
        // GET: SinhVienController
        public ActionResult Index()
        {
            Models.MongoDBSetings.ConnectToMongoService();
            Models.MongoDBSetings.sinhvien_colecttion =
                Models.MongoDBSetings.database.GetCollection<Models.SinhVien>("sinhvien");
            var filter = Builders<Models.SinhVien>.Filter.Ne("_id", "");
            var result = Models.MongoDBSetings.sinhvien_colecttion.Find(filter).ToList();
            return View(result);
        }

        // GET: SinhVienController/Details/5
        public ActionResult Details(string id)
        {
            Models.MongoDBSetings.ConnectToMongoService();
            Models.MongoDBSetings.sinhvien_colecttion =
                Models.MongoDBSetings.database.GetCollection<Models.SinhVien>("sinhvien");
            var filter = Builders<Models.SinhVien>.Filter.Eq("_id", id);
            var result = Models.MongoDBSetings.sinhvien_colecttion.Find(filter).SingleOrDefault();
            return View(result);
        }

        // GET: SinhVienController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SinhVienController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Models.MongoDBSetings.ConnectToMongoService();
                Models.MongoDBSetings.sinhvien_colecttion =
                    Models.MongoDBSetings.database.GetCollection<Models.SinhVien>("sinhvien");

                Object id = GenerateRandomId(24);
                //Create sinh vien
                string dateString = collection["NgaySinh"].ToString();
                DateTime dateTime = DateTime.Parse(dateString);
                Models.MongoDBSetings.sinhvien_colecttion.InsertOneAsync(new Models.SinhVien {
                _id = id,
                MaSV = collection["MaSV"].ToString(),
                TenSV = collection["TenSV"].ToString(),
                NgaySinh = dateTime,
                DiaChi = collection["DiaChi"].ToString(),
                });
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private static Random random = new Random();
        private object GenerateRandomId(int v)
        {
            string strarray = "abcdefghijklmnopqrstuvwxyz123456789";
            return new string(Enumerable.Repeat(strarray, v).Select(s => s[random.Next(s.Length)]).ToArray());
        }



        // GET: SinhVienController/Edit/5
        public ActionResult Edit(string id)
        {
            Models.MongoDBSetings.ConnectToMongoService();
            Models.MongoDBSetings.sinhvien_colecttion =
                Models.MongoDBSetings.database.GetCollection<Models.SinhVien>("sinhvien");
            var filter = Builders<Models.SinhVien>.Filter.Eq("_id", id);
            var result = Models.MongoDBSetings.sinhvien_colecttion.Find(filter).SingleOrDefault();
            return View(result);
        }

        // POST: SinhVienController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, IFormCollection collection)
        {
            try
            {
                Models.MongoDBSetings.ConnectToMongoService();
                Models.MongoDBSetings.sinhvien_colecttion =
                    Models.MongoDBSetings.database.GetCollection<Models.SinhVien>("sinhvien");
                var filter = Builders<Models.SinhVien>.Filter.Eq("_id", id);
                string dateString = collection["NgaySinh"].ToString();
                DateTime date = DateTime.Parse(dateString);
                var update = Builders<Models.SinhVien>.Update.Set("MaSV", collection["MaSV"])
                    .Set("TenSV", collection["TenSV"]).Set("NgaySinh",date).Set("DiaChi", collection["DiaChi"]);
                var result = Models.MongoDBSetings.sinhvien_colecttion.UpdateOneAsync(filter, update);  
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SinhVienController/Delete/5
        public ActionResult Delete(string id)
        {
            Models.MongoDBSetings.ConnectToMongoService();
            Models.MongoDBSetings.sinhvien_colecttion = Models.MongoDBSetings.database.GetCollection<SinhVien>("sinhvien");
            var filter = Builders<SinhVien>.Filter.Eq("_id", id);
            var result = MongoDBSetings.sinhvien_colecttion.Find(filter).FirstOrDefault();
            return View(result);
        }

        // POST: SinhVienController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            try
            {
                MongoDBSetings.ConnectToMongoService();
                MongoDBSetings.sinhvien_colecttion = MongoDBSetings.database.GetCollection<SinhVien>("sinhvien");
                var filter = Builders<SinhVien>.Filter.Eq("_id", id);
                var result = MongoDBSetings.sinhvien_colecttion.DeleteOneAsync(filter);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
