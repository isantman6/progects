using BookStore.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Areas.AdminArea.Data
{
    public class AddItemVM
    {
        public AddItemVM()
        {
            item = new Item();
            categories = new List<Category>();
        }
        public Item item { get; set; }
        public List<Category> categories { get; set; }
    }
}