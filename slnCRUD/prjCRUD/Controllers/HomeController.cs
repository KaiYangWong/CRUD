using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//加入要引用的模型
using prjCRUD.Models; 

namespace prjCRUD.Controllers
{
    public class HomeController : Controller
    {
        CompanyEntities db = new CompanyEntities();

        //將讀取出來的資料顯示在頁面上
        public ActionResult Index()
        {
            var emps = db.Employee.OrderByDescending(m => m.fId).ToList();
            return View(emps);
        }

        //新增
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string fName,string fPhone,int fSalary)
        {
            Employee emp = new Employee();
            emp.fName = fName;
            emp.fPhone = fPhone;
            emp.fSalary = fSalary;
            db.Employee.Add(emp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //編輯
        public ActionResult Update(int fId)
        {
            //找到指定的id
            var emp = db.Employee.Where(m => m.fId == fId).FirstOrDefault();
            return View(emp);
        }

        [HttpPost]
        public ActionResult Update(int fId,string fName,string fPhone,int fSalary)
        {
            var emp = db.Employee.Where(m => m.fId == fId).FirstOrDefault();
            emp.fName = fName;
            emp.fPhone = fPhone;
            emp.fSalary = fSalary;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //刪除
        public ActionResult Delete(int fId)
        {
            var emp = db.Employee.Where(m => m.fId == fId).FirstOrDefault();
            db.Employee.Remove(emp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}