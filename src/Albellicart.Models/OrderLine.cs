using Albellicart.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Albellicart.Models
{
    public class OrderLine
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public ProductType ProductType { get; set; }
        public int Quantity { get; set; }
        public Order Order { get; set; }
    }
}
