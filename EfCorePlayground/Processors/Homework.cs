using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfCorePlayground.Data;
using EfCorePlayground.Models;

namespace EfCorePlayground.Processors {
    public class Homework {
        public void Run() {
            //CreateProducts();
            //int productId = GetRandomProduct();
            //int customerId = GetRandomCustomer();
            //CreateOrder(customerId, productId);
            //UpdateItemQuantity(orderId,productId,6);
            //productId = GetRandomProduct();
            //BuyAnotherProduct(orderId, productId);
        }

        //private int GetRandomProduct() {
        //    using var context = new CustomerContext();
        //    var min = context.Products.Min(p => p.ProductId);
        //    var max = context.Products.Max(p => p.ProductId);
        //    var random = new Random();
        //    return random.Next(min, max);
        //}
    }
}
