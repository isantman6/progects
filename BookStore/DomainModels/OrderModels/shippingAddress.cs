using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.DomainModels.OrderModels
{
    public class shippingAddress
    {
        public string City { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public string ZipNumber { get; set; }

        
    }
}