using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PSP.Enums;

namespace PSP.Models;

[Table("Station")]
public class Station
{
    [Key]
    public Guid stationId { get; set; }
    public Guid locationId { get; set; }
    public Guid employeeId { get; set; }
    public int seats { get; set; }
    public StationStatus status { get; set; }
}