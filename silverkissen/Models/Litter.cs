using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace silverkissen.Models
{
    public abstract class Litter
    {
        [Key]
        public int Id { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime ReadyDate { get; set; } 
        public String Notes { get; set; }
        public bool Vaccinated { get; set; }
        public bool Chipped { get; set; }
        public bool Pedigree { get; set; }
        public String PedigreeName { get; set; }
        public String Status { get; set; }
        public int AmountOfKids { get; set; }

        public enum LitterStatus
        {
            ARCHIVED,
            ACTIVE,
            EARLIER_LITTER
        }
    }
}
