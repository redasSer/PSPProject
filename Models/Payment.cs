using System;
using System.ComponentModel.DataAnnotations.Schema;
using PSP.Enums;

namespace PSP.Models;

[Table("Payment")]
public class Payment
{
    public Guid id { get; set; }
    public Guid clientId { get; set; }
    public Guid orderId { get; set; }
    public int amount { get; set; }
    public string comment { get; set; }
    public DateTime date { get; set; }
    public PaymentMethod method { get; set; }
    public PaymentStatus status { get; set; }
}