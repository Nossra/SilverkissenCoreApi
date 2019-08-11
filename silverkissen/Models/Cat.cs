//using silverkissen.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace silverkissen.Models
{
    public class Cat : Animal, ICat
    { 
        public bool Pedigree { get; set; }
        public bool Chipped { get; set; }
        public bool Vaccinated { get; set; }
        public ICollection<Cat_Image> Images { get; set; } = new List<Cat_Image>();
        public CatLitter CatLitter { get; set; }

        public Cat()
        {

        }

        public Cat(DateTime BirthDate)
        {
            this.BirthDate = BirthDate; 
        }


    }
}
