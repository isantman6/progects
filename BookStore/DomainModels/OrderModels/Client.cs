using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.DomainModels.OrderModels
{
    public class Client
    {

        public int Id { get; set; }
        public string FullName { get; set; }
        public shippingAddress Address { get; set; }
        public string Mail { get; set; }
        public string PhonNumber { get; set; }
    }
}