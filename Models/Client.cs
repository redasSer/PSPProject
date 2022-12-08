using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSP.Models
{
    [Table("Client")]
    public class Client
    {
        public Guid clientId { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string currency { get; set; }
        public string timezone { get; set; }
    }
}