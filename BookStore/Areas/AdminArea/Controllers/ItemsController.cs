using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookStore.Areas.AdminArea.Data;
using BookStore.DAL;
using BookStore.DomainModels;

namespace BookStore.Areas.AdminArea.Controllers
{
    public class ItemsController : Controller
    {
        private StoreContext db = new StoreContext();

        // GET: AdminArea/Items
        public ActionResult Index()
        {
            var items = db.items.Include(i => i.categories)
                  .AsNoTracking().ToList();
          
            return View(items);
        }

        // GET: AdminArea/Items/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.items
                .Include(i => i.categories).AsNoTracking()
                .FirstOrDefault(s => s.Id == id);

            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: AdminArea/Items/Create
        public ActionResult Create()
        {
            AddItemVM model = new AddItemVM();
            model.categories = db.categories.ToList();
            return View(model);
        }


        // POST: AdminArea/Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Author,Description,Price,ImgUrl,AmountInStack")] Item item)
        {
            var category = db.categories.Find(Convert.ToInt32(Request["CategoryID"]));
            item.categories.Add(category);
            if (ModelState.IsValid)
            {
                db.items.Add(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            PopulateCategoryDropDownList(item.CatgoryId);

            return View(item);
        }

        // GET: AdminArea/Items/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: AdminArea/Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Author,Description,Price,ImgUrl,AmountInStack,CatgoryId")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(item);
        }

        // GET: AdminArea/Items/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: AdminArea/Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Item item = db.items.Find(id);
            db.items.Remove(item);
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

        //get
        public ActionResult CreateCtegory()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatCtegory([Bind(Include = "Id,Name")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("CategoryIndex");
            }
            return View(category);

            
        }
        private void PopulateCategoryDropDownList(object selectedDepartment = null)
        {
            var CategoriesQuery = from d in db.categories
                                   orderby d.Name
                                   select d;
            ViewBag.DepartmentID = new SelectList(CategoriesQuery, "Id", "Name", selectedDepartment);
        }
        public void CreatItem()
        {
            var item = new Item { Name = "mm", AmountInStack = 1 };
            db.items.Add(item);
            db.SaveChanges();
        }
    }
    
}
