using BookStore.DAL;
using BookStore.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Areas.AdminArea.Data
{
    public class ItemIndexVM
    {
        private StoreContext db = new StoreContext();
        public ItemIndexVM()
        {
            
        }
        public Item item { get; set; }
        public List<Category> categories { get; set; }
    }
}