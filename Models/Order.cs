using PSP.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSP.Models;

[Table("Order")]
public class Order
{
    [Required]
    [Key]
    public Guid OrderId { get; set; }
    public Guid CustomerId { get; set; }
    internal virtual Customer Customer { get; set; }
    public DateTime Placed { get; set; }
    public DateTime Completed { get; set; }
    public Guid EmployeeId { get; set; }
    internal virtual Employee Employee { get; set; }
    public string Comment { get; set; }
    [EnumDataType(typeof(OrderStatus))]
    public OrderStatus Status { get; set; }
    public double Tip { get; set; }
}