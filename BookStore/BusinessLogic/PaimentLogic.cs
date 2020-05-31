using BookStore.DomainModels;
using BookStore.DomainModels.OrderModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.BusinessLogic
{
    public class PaymentLogic
    {
        public float TotalPaymentCalcolator(OrderItem orderItem)
        {
            var Total = orderItem.Price * orderItem.AmountToOrder;
            return Total;
        }
    }
}