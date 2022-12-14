// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Api
{
    public partial class Employee
    {
        public Employee()
        {
            TrainingEnrolleds = new HashSet<TrainingEnrolled>();
            TrainingRequests = new HashSet<TrainingRequest>();
        }

        public int Id { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public bool? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? PhoneNo { get; set; }
        public int? ManagerId { get; set; }

        public virtual Manager Manager { get; set; }
        public virtual ICollection<TrainingEnrolled> TrainingEnrolleds { get; set; }
        public virtual ICollection<TrainingRequest> TrainingRequests { get; set; }
    }
}