//using _23DH112625_MyStore.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace _23DH112625_MyStore.Areas.Admin.Controllers
//{
//    public class ProductsController : Controller
//    {
//        private MystoreEntities db = new MystoreEntities();
//        // GET: Admin/Products
//        public ActionResult Index()
//        {
//            var products = db.Products.Include( p = p => p.Category);
          
//            return View(products.ToList());
//        }
//    }
//}