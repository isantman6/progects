using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace BookStore.DomainModels
{
    public class Category
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public List<Item> Items { get; set; }
        public bool Assigned { get; internal set; }
        public string ImgUrl { get; set; }
       // public System.Web.UI.WebControls.Image _Image { get; set; }
    }
}