using ConnectToMongoDB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace ConnectToMongoDB.Controllers
{
    public class TaiKhoanController : Controller
    {
        // GET: TaiKhoanController
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DangNhap(string tenDangNhap, string matKhau)
        {
            MongoDBSetings.ConnectToMongoService();
            MongoDBSetings.taikhoan_colection = MongoDBSetings.database.GetCollection<TaiKhoan>("taikhoan");
            var filter = Builders<TaiKhoan>.Filter.And(
                Builders<TaiKhoan>.Filter.Eq(x => x.TenDangNhap, tenDangNhap),
            Builders<TaiKhoan>.Filter.Eq(y => y.MatKhau, matKhau)
    );
            var data = MongoDBSetings.taikhoan_colection.Find(filter).FirstOrDefault();
            if(data != null)
            return RedirectToAction("Index", "Home");
            else return Json( new {success=false});
        }
        // GET: TaiKhoanController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TaiKhoanController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TaiKhoanController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TaiKhoanController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TaiKhoanController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TaiKhoanController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TaiKhoanController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
