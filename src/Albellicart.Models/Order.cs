using System;
using System.Collections.Generic;

namespace Albellicart.Models
{
    public class Order
    {
        public int Id { get; set; }

        public IEnumerable<OrderLine> OrderLine { get; set; }

        public int RequiredBinWidth { get; set; }
    }
}
