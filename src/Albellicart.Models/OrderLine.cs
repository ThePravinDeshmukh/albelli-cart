using Albellicart.Models.Enums;
using System;
using System.Collections.Generic;

namespace Albellicart.Models
{
    public class OrderLine
    {
        public ProductType ProductType { get; set; }
        public int Quantity { get; set; }
    }
}
