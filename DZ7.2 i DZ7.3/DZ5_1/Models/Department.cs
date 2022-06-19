using System;
using System.Collections.Generic;

#nullable disable

namespace DZ5_1.Models
{
    public partial class Department
    {
        public Department()
        {
            Department = new HashSet<movieCast>();
        }

        public int department_id { get; set; }
        public string department_name { get; set; }
        

        public virtual ICollection<movieCast> MovieCast{ get; set; }
    }
}
