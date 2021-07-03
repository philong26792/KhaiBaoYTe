using System;
using System.ComponentModel.DataAnnotations;

namespace KhaiBaoYTe_API.Models
{
    public class Employee
    {
        [Key]
        public int EmpID { get; set;}
        public string EmpName { get; set; }
        public string EmpNumber  { get; set; }
        public DateTime? DateIn { get; set; }
        public int PositionID { get; set; }
        public string Descript { get; set; }
        public int? GBID { get; set; }
        public bool? Visible { get; set; }
        public int? PartID { get; set; }
    }
}