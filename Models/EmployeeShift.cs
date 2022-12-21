using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSP.Models;

[Table(nameof(EmployeeShift))]

public class EmployeeShift
{

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public Guid EmployeeShiftId { get; set; }

    [Required]
    public Guid EmployeeId { get; set; }
    internal virtual Employee employee { get; set; }

    [Required]
    public Guid ShiftId { get; set; }
    internal virtual Shift shift { get; set; }

    [Required]
    public DateTime WorkDay { get; set; }

}

