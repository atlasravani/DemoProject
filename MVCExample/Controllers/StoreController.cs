using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCExample.Models;

namespace MVCExample.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult StoreList()
        {
            List<Store> stores;
            using (var db = new ExerciseEntities())
            {
                stores = db.Stores.ToList();
            }
            return View(stores);
        }
        public ActionResult StaffList()
        {
            List<Staff> staff;
            using (var db = new ExerciseEntities())
            {
                staff = db.Staffs.ToList();
            }
            return View(staff);
        }
        public ActionResult CustomerList()
        {
            List<Customer> customer;
            using (var db = new ExerciseEntities())
            {
                customer = db.Customers.ToList();
            }
            return View(customer);
        }
        public ActionResult ProductsList()
        {
            List<Product> products;
            using (var db = new ExerciseEntities())
            {
                products = db.Products.ToList();
            }
            return View(products);
        }
        public ActionResult ProductListJson()
        {
            JsonResult result;
            using (var db = new ExerciseEntities())
            {
                var Products = db.Products.Select(x => new
                {
                    x.ID,
                    x.Name,
                    x.Price
                }).ToList();
                result = this.Json(Products, JsonRequestBehavior.AllowGet);
            }
            return result;
        }
        public ActionResult TransactionList()
        {
            List<PurchaseHead> head;
            using (var db = new ExerciseEntities())
            {
                head = db.PurchaseHeads
                    .Include("PurchaseLines.Product")
                    .Include("Customer")
                    .Include("Staff")
                    .Include("Store").ToList();
            }
            return View(head);
        }
        public ActionResult NewCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewCustomer(Customer c)
        {
            using (var db = new ExerciseEntities())
            {
                db.Customers.Add(c);
                db.SaveChanges();
            }
            return RedirectToAction("CustomerList");
        }
        public ActionResult NewProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewProduct(Product p)
        {
            using (var db = new ExerciseEntities())
            {
                db.Products.Add(p);
                db.SaveChanges();
            }
            return RedirectToAction("ProductsList");
        }
        public ActionResult NewStaff()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewStaff(Staff s)
        {
            using (var db = new ExerciseEntities())
            {
                db.Staffs.Add(s);
                db.SaveChanges();
            }
            return RedirectToAction("StaffList");
        }
        public ActionResult NewPurchaseHead()
        {
            CreatePurchaseHeadViewModel model = new CreatePurchaseHeadViewModel();
            using (var db = new ExerciseEntities())
            {
                model.staff = db.Staffs.ToList();
                model.customers = db.Customers.ToList();
                model.stores = db.Stores.ToList();
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult NewPurchaseHead(PurchaseHead ph)
        {
            using (var db = new ExerciseEntities())
            {
                db.PurchaseHeads.Add(ph);
                db.SaveChanges();
            }
            return RedirectToAction("NewPurchaseLine", new { HeadID = ph.ID });
        }
        public ActionResult NewPurchaseLine(int hID)
        {
            CreatePurchaseLineViewModel model;
            using (var db = new ExerciseEntities())
            {
                model = new CreatePurchaseLineViewModel()
                {
                    header = db.PurchaseHeads.Include("Customer").Include("Staff").Include("Store").Single(x => x.ID == 1),
                    products = db.Products.ToList()
                };
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult NewPurchaseLine(PurchaseLine pl)
        {
            using (var db = new ExerciseEntities())
            {
                db.PurchaseLines.Add(pl);
                db.SaveChanges();
            }
            int val = pl.HeadID.Value;
            return NewPurchaseLine(val);
        }
    }
}