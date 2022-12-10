using AutoMapper;
using Newtonsoft.Json;
using PSP.entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PSP.Models
{
    public class EmployeeShiftsModel
    {
        [JsonProperty("employeeShiftsId")]
        public string EmployeeShiftsId { get; set; }

        [JsonProperty("employeeId")]
        [Required]
        public string EmployeeId { get; set; }

        [JsonProperty("shiftId")]
        [Required]
        public string ShiftId { get; set; }

        [JsonProperty("workDay")]
        [Required]
        public DateOnly WorkDay { get; set; }

        public EmployeeShift Convert()
        {
            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<EmployeeShiftsModel, EmployeeShift>()
                .ForMember(dest => dest.WorkDay, act => act.Ignore())
                .ForMember(dest => dest.EmployeeShiftsId, act => act.Ignore()));
            var mapper = new Mapper(config);
            EmployeeShift employeeShift = mapper.Map<EmployeeShiftsModel, EmployeeShift>(this);

            employeeShift.WorkDay = this.WorkDay.Convert();
            try
            {
                employeeShift.EmployeeShiftsId = Guid.Parse(this.EmployeeShiftsId);
            }
            catch (ArgumentNullException)
            {
                employeeShift.EmployeeShiftsId = new Guid();
            }
            catch (FormatException)
            {
                employeeShift.EmployeeShiftsId = new Guid();
            }

            return employeeShift;
        }

        public static EmployeeShiftsModel Convert( EmployeeShift employeeShift)
        {
            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<EmployeeShift, EmployeeShiftsModel>()
                .ForMember(dest => dest.WorkDay, act => act.Ignore()));
            var mapper = new Mapper(config);
            EmployeeShiftsModel employeeShiftsModel = mapper.Map<EmployeeShift, EmployeeShiftsModel>(employeeShift);
            employeeShiftsModel.WorkDay = DateOnly.Convert(employeeShift.WorkDay);
            return employeeShiftsModel;
        }

        public static List<EmployeeShiftsModel> Convert(List<EmployeeShift> employeeShifts)
        {
            List<EmployeeShiftsModel> employeeShiftsModels = new List<EmployeeShiftsModel>();
            employeeShifts.ForEach(shift => employeeShiftsModels.Add(Convert(shift)));
            return employeeShiftsModels;
        }
    }
}
