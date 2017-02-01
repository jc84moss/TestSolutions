﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSolutions.Domain.Common;
using TestSolutions.Domain.Orders;

namespace TestSolutions.Domain.OrderDetails
{
    public class OrderDetail : IEntity
    {
        public Order Order { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }

    }
}
