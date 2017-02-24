﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using TestSolutions.Domain.Customers;
using TestSolutions.Domain.OrderDetails;
using TestSolutions.Domain.Orders;
using TestSolutions.Domain.Shippers;

namespace TestSolutions.Repository.EF
{
    public class TestSolutionsInitializer : DropCreateDatabaseIfModelChanges<TestSolutionsService>
    {
        protected override void Seed(TestSolutionsService context)
        {
            base.Seed(context);

            CreateCustomer(context);

            CreateShipper(context);

            CreateSales(context);

            CreateOrderDetails(context);
        }

        
        private void CreateCustomer(TestSolutionsService context)
        {
            context.Customers.Add(new Customer() { ContactName = "Colleen Dunn", CompanyName = "Best Buy" });
            context.Customers.Add(new Customer() { ContactName = "Bill McCorey", CompanyName = "Circuit City" });
            context.Customers.Add(new Customer() { ContactName = "Michael Cooper", CompanyName = "Game Stop" });
            context.SaveChanges();
        }

        private void CreateShipper(TestSolutionsService context)
        {
            context.Shippers.Add(new Shipper() { CompanyName = "DHL", ContactName = "Ricardo A. Bartra" });
            context.Shippers.Add(new Shipper() { CompanyName = "FedEx", ContactName = "Rob Carter" });
            context.Shippers.Add(new Shipper() { CompanyName = "UPS", ContactName = "Juan R. Perez" });
            context.SaveChanges();
        }

        private void CreateSales(TestSolutionsService context)
        {
            var shippers = context.Shippers.ToList();

            var customers = context.Customers.ToList();

            context.Orders.Add(new Order()
            {
                Comments = "TestComments",
                CreationDateTime = DateTime.Now.Date.AddDays(2),
                Customer = customers[0],
                Shipper = shippers[0],
                Total = 1
            });
            context.SaveChanges();

        }

        private void CreateOrderDetails(TestSolutionsService context)
        {
            var orders = context.Orders.ToList();

            context.OrderDetails.Add(new OrderDetail()
            {
                Order = orders[0],
                ProductName = "TestProductName",
                Quantity = 1000,
                Total = 120.00m,
                UnitPrice = 12 
            });
            context.SaveChanges();

        }

    }
}
