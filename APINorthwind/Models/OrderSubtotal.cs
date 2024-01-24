using System;
using System.Collections.Generic;

namespace APINorthwind.Models;

public partial class OrderSubtotal
{
    public int OrderId { get; set; }

    public double? Subtotal { get; set; }
}
