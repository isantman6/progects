using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.DomainModels.OrderModels
{
    public class Order
    {

        public int Id { get; set; }
        public List<OrderItem> MyItems { get; set; }
        public Client client { get; set; }
        public float  TotalPayment { get; set; }
        public bool Paid { get; set; }
    }
}