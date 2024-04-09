using ConnectToMongoDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using MongoDB.Driver;

namespace ConnectToMongoDB.Controllers
{
    public class MonHocController : Controller
    {
        // GET: MonHocController
        public ActionResult Index()
        {
            MongoDBSetings.ConnectToMongoService();
            MongoDBSetings.monhoc_collection = 
                MongoDBSetings.database.GetCollection<MonHoc>("monhoc");
            var filter = Builders<MonHoc>.Filter.Ne("_id","");
            var result = MongoDBSetings.monhoc_collection.Find(filter).ToList();
            return View(result);
        }

        // GET: MonHocController/Details/5
        public ActionResult Details(string id)
        {
            MongoDBSetings.ConnectToMongoService();
            MongoDBSetings.monhoc_collection = MongoDBSetings.database.GetCollection<MonHoc>("monhoc");
            var filter = Builders<MonHoc>.Filter.Eq("_id", id);
            var result = MongoDBSetings.monhoc_collection.Find(filter).SingleOrDefault();
            return View(result);
        }

        // GET: MonHocController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MonHocController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                MongoDBSetings.ConnectToMongoService();
                MongoDBSetings.monhoc_collection = MongoDBSetings.database.GetCollection<MonHoc>("monhoc");
                Object id = GenerateRandomId(24);
                MongoDBSetings.monhoc_collection.InsertOneAsync(new MonHoc
                {
                    _id = id,
                    MaMH = collection["MaMH"].ToString(),
                    TenMH = collection["TenMH"].ToString(),
                    SoTinChi = Int32.Parse(collection["SoTinChi"].ToString())
                });
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public static Random random = new Random();
        private object GenerateRandomId(int v)
        {
            string strarray = "abcdefghijklmnopqrstuvwxyz123456789";
            return new string(Enumerable.Repeat(strarray, v).Select(s => s[random.Next(s.Length)]).ToArray());
        }
        // GET: MonHocController/Edit/5
        public ActionResult Edit(string id)
        {
            MongoDBSetings.ConnectToMongoService();
            MongoDBSetings.monhoc_collection = MongoDBSetings.database.GetCollection<MonHoc>("monhoc");
            var filter = Builders<MonHoc>.Filter.Eq("_id", id);
            var result = MongoDBSetings.monhoc_collection.Find(filter).SingleOrDefault();
            return View(result);
        }

        // POST: MonHocController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, IFormCollection collection)
        {
            try
            {
                MongoDBSetings.ConnectToMongoService();
                MongoDBSetings.monhoc_collection = MongoDBSetings.database.GetCollection<MonHoc>("monhoc");
                var filter = Builders<MonHoc>.Filter.Eq("_id", id);
                var update = Builders<MonHoc>.Update.Set("MaMH", collection["MaMH"]).Set("TenMH", collection["TenMH"])
                    .Set("SoTinChi", Int32.Parse(collection["SoTinChi"].ToString()));
                var result = MongoDBSetings.monhoc_collection.UpdateOneAsync(filter, update);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MonHocController/Delete/5
        public ActionResult Delete(string id)
        {
            MongoDBSetings.ConnectToMongoService();
            MongoDBSetings.monhoc_collection = MongoDBSetings.database.GetCollection<MonHoc>("monhoc");
            var filter = Builders<MonHoc>.Filter.Eq("_id", id);
            var restult = MongoDBSetings.monhoc_collection.Find(filter).SingleOrDefault();
            return View();
        }

        // POST: MonHocController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            try
            {
                MongoDBSetings.ConnectToMongoService();
                MongoDBSetings.monhoc_collection = MongoDBSetings.database.GetCollection<MonHoc>("monhoc");
                var filter = Builders<MonHoc>.Filter.Eq("_id", id);
                var restult = MongoDBSetings.monhoc_collection.DeleteOneAsync(filter);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
