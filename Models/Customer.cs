using System;
using System.ComponentModel.DataAnnotations.Schema;
using PSP.Enums;

namespace PSP.Models;

[Table("Customer")]
public class Customer
{
    public Guid customerId { get; set; }
    public Guid clientId { get; set; }
    public string username { get; set; }
    public string password { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string email { get; set; }
    public string phoneNumber { get; set; }
    public CustomerStatus status { get; set; }
}