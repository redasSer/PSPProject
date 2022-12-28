using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSP.Models;

[Table("UsedDiscountCode")]
[PrimaryKey(nameof(Code), nameof(ClientId), nameof(OrderId))]
public class UsedDiscountCode
{
    public string Code { get; set; }
    public Guid ClientId { get; set; }
    internal virtual DiscountCode DiscountCode { get; set; }
    public Guid OrderId { get; set; }
    internal virtual Order Order { get; set; }
}