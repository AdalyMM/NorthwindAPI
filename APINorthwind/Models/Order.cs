﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace APINorthwind.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public string? CustomerId { get; set; }

    public int? EmployeeId { get; set; }

    public DateTime? OrderDate { get; set; }

    public DateTime? RequiredDate { get; set; }

    public DateTime? ShippedDate { get; set; }

    public int? ShipVia { get; set; }

    public decimal? Freight { get; set; }

    public string? ShipName { get; set; }

    public string? ShipAddress { get; set; }

    public string? ShipCity { get; set; }

    public string? ShipRegion { get; set; }

    public string? ShipPostalCode { get; set; }

    public string? ShipCountry { get; set; }
    [JsonPropertyName("customer")]
    public virtual Customer? Customer { get; set; }
    [JsonPropertyName("employee")]
    public virtual Employee? Employee { get; set; }
    [JsonPropertyName("orderDetails")]
    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    [JsonPropertyName("shipViaNavigation")]
    public virtual Shipper? ShipViaNavigation { get; set; }

}
