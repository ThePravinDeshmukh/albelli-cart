﻿using Albellicart.Models.Enums;
using System;
using System.Collections.Generic;

namespace Albellicart.Models
{
    public class Product
    {
        public ProductType ProductType { get; set; }

        public double WidthInmm { get; set; }
        public int WidthFactor { get; set; }
    }
}
