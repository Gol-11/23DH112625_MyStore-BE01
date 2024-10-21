﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _23DH112625_MyStore.Models;

namespace _23DH112625_MyStore.Areas.Admin.Controllers
{
    public class CategoriesController : Controller
    {
        private MystoreEntities db = new MystoreEntities();

        // GET: Admin/Categories1
        // GET: Lay du lieu tu bang Category trong DB de hien thi len
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        // GET: Admin/Categories1/Details/5
        // Details: Lay chi tiet mot ban ghi co CategoryID = id
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest); // Ma loi 400: Thieu gia tri truyen vao
            }
            Category category = db.Categories.Find(id);
            if (category == null) // khong tim thay ban ghi
			{
                return HttpNotFound(); // ma loi 404
            }
            return View(category);
        }

        // GET: Admin/Categories1/Create
        // Load form create
        //[HttpGet] la phuong thuc mac dinh, nen khong can khai bao tu khoa
        public ActionResult Create()
        {
            return View();
        }

       

        // GET: Admin/Categories1/Edit/5
        // GET: lay du lieu cua mot danh muc da co sao cho CategoryID = id
        public ActionResult Edit(int? id)
        {
            Details(id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Admin/Categories1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryID,CategoryName")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }
		// POST: Admin/Categories1/Create
		// POST: luu du lieu nhap vao tu form Create DB
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "CategoryID,CategoryName")] Category category)
		{
			if (ModelState.IsValid)
			{
				db.Categories.Add(category);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(category);
		}
		// GET: Admin/Categories1/Delete/5
		public ActionResult Delete(int? id)
        {
            Details(id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Admin/Categories1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
