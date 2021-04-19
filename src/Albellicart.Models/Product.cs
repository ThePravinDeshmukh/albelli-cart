using Albellicart.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Albellicart.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public ProductType ProductType { get; set; }

        public double WidthInmm { get; set; }
        public int WidthFactor { get; set; }
    }
}
