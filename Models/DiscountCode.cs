using Microsoft.EntityFrameworkCore;
using PSP.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSP.Models;

[Table("DiscountCode")]
[PrimaryKey(nameof(Code), nameof(ClientId))]
public class DiscountCode
{
    [Required]
    [Key]
    public string Code { get; set; }
    [Required]
    [Key]
    public Guid ClientId { get; set; }
    internal virtual Client Client { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public double Discount { get; set; }
    [EnumDataType(typeof(DiscountCodeStatus))]
    public DiscountCodeStatus Status { get; set; }
}