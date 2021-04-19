using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Albellicart.Models
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public List<OrderLine> OrderLine { get; set; } = new List<OrderLine>();

        public double RequiredBinWidth { get; set; }
    }
}
