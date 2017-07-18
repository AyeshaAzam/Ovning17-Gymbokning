using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gymbokning_v0._1.Models
{
    public class GymClass
    {
      
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime EndTime { get { return StartTime + Duration; } }
        public string Description { get; set; }

        // navigation property
        [Display (Name = "Full Name")]
        public virtual ICollection<ApplicationUser> AttendingMembers { get; set; }  
    }
}