using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace silverkissen.Models
{
    public abstract class Animal
    {
        [Key]
        public int Id { get; set; }
        public DateTime BirthDate { get; set; }
        public String Notes { get; set; }
        public int Age { get; set; }
        public String Breed { get; set; }
        public String Color { get; set; }
        public String Name { get; set; }
        public String Sex { get; set; }
        public bool Parent { get; set; } 
    }
}
