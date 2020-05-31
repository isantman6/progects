using BookStore.DAL;
using BookStore.DomainModels;
using BookStore.DomainModels.OrderModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.BusinessLogic
{
    public class SubtractingItemfromDB
    {
        public StoreContext db = new StoreContext();
        public SubtractingItemfromDB(Order order)
        {
            items = order.MyItems; 

        }
        public List<OrderItem> items;
        
        public void SubtractingItems()
        {
            foreach (var OrderItem in items)
            {
                var DBitem = db.items.Find(OrderItem.Id);
               // db.items.RemoveRange(1)
                DBitem.AmountInStack -= OrderItem.AmountToOrder;
                db.SaveChanges();
            }
        }
    }
}