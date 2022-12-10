using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSP.entity
{
    [Table(nameof(EmployeeShift))]

    public class EmployeeShift
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid EmployeeShiftsId { get; set; }

        [Required]
        public string EmployeeId { get; set; }

        [Required]
        public string ShiftId { get; set; }

        [Required]
        public DateTime WorkDay { get; set; }

    }
}
