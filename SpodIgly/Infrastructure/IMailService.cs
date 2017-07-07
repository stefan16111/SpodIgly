using SpodIgly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpodIgly.Infrastructure
{
    public interface IMailService
    {
        void SendOrderConfirmationEmail(Order order);
        void SendOrderShippedEmail(Order order);
    }
}