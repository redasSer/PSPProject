using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PSP.Enums;

namespace PSP.Models;

public class Receipt
{
    public Guid ClientId { get; set; }
    public Order Order { get; set; }
    public List<OrderedItem> OrderedItems { get; set; }
    public double Total { get; set; }
}