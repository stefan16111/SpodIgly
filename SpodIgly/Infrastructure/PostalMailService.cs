using SpodIgly.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpodIgly.Infrastructure
{
    public class PostalMailService : IMailService
    {
        public void SendOrderConfirmationEmail(Models.Order order)
        {
            // Strongly typed - without background
            OrderConfirmationEmail email = new OrderConfirmationEmail();
            email.To = order.Email;
            email.Cost = order.TotalPrice;
            email.OrderNumber = order.OrderId;
            email.FullAddress = string.Format("{0} {1}, {2}, {3}", order.FirstName, order.LastName, order.Address, order.CodeAndCity);
            email.OrderItems = order.OrderItems;
            email.CoverPath = AppConfig.PhotosFolderRelative;
            email.Send();
        }

        public void SendOrderShippedEmail(Models.Order order)
        {
            OrderShippedEmail email = new OrderShippedEmail();
            email.To = order.Email;
            email.OrderId = order.OrderId;
            email.FullAddress = string.Format("{0} {1}, {2}, {3}", order.FirstName, order.LastName, order.Address, order.CodeAndCity);
            email.Send();
        }
    }
}