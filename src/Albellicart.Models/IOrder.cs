using System.Collections.Generic;

namespace Albellicart.Models
{
    public interface IOrder
    {
        int Id { get; set; }
        IEnumerable<OrderLine> OrderLine { get; set; }
        double RequiredBinWidth { get; set; }
    }
}