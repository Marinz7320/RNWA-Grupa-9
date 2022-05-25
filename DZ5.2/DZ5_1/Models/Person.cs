using System;
using System.Collections.Generic;

#nullable disable

namespace DZ5_1.Models
{
    public partial class Person
    {
        public Person()
        {
           movieCast = new HashSet<MovieCast>();
        }

        public string person_id { get; set; }
        public string person_name { get; set; }
        

        public virtual ICollection<movieCast> MovieCast{ get; set; }
    }
}
