using BookStore.DAL;
using BookStore.DomainModels;
using BookStore.DomainModels.OrderModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Areas.PublicArea.Controllers
{
    public class PublicController : Controller
    {
        private StoreContext db = new StoreContext();

        // GET: PublicArea/Public
        public ActionResult CategoryIndex()
        {
            List<Category> categories = new List<Category>();
            categories = db.categories.ToList();
            
            return View(categories);
        }
        public ActionResult CategoryItemsIndex(int? CategoryId)
        {


            var category = db.categories.Include(c => c.Items).AsNoTracking().FirstOrDefault(c => c.Id == CategoryId);
            var items = category.Items;
            return View(items);
        }

        public ActionResult ItemDitels(int? ItemId)
        {


            var items = db.items.Find(ItemId);
            return View(items);
        }

       
        //get
        public ActionResult OrderNow(int? ItemId, int? AmountToBuy)
       {

            var item = db.items.Find(ItemId);
            var itemOrder =new OrderItem(item,3 /*Convert.ToInt32( AmountToBuy)*/);

            ViewBag.address =new shippingAddress();
            ViewBag.client = new Client();
             var Order = new Order() ;
            Order.MyItems = new List<OrderItem>();
            Order.MyItems.Add(itemOrder);
            db.orders.Add(Order);
            db.SaveChanges();
            return View(Order);
        }

        [HttpPost]
        public ActionResult OrderDitels([Bind(Include = "City,Street,HouseNumber,ZipNumber")] shippingAddress adddress )
        {
            Client client = new Client()
            {
                FullName = Request["Name"],
                PhonNumber=Request["PhonNumber"],
                Mail=Request["Mail"],
                Address=adddress
                
            };

            db.clients.Add(client);
            var order = db.orders.Find(Convert.ToInt32(Request["OrderId"]));
            order.client = client;
            
            db.SaveChanges();
            return View(order);
        }



        public ActionResult AddToCart(int?  ItemId)
        {
            //var ItemId =Convert.ToInt32( Request["ItemId"]);
            var items = db.items.Find(7);
            return View(items);
        }
        public void AddOrderItem ()
        {
            var item = db.items.Find(1);
            var OrderItem = new OrderItem(item, 2);
        }


    }
}