using silverkissen.DbModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace silverkissen.Models
{
    public class Cat : Animal
    {
        public bool SVERAK { get; set; }
        public bool Pedigree { get; set; }
        public bool Chipped { get; set; }
        public bool Vaccinated { get; set; }
        public ICollection<CatImages> CatImages { get; } = new List<CatImages>();
        public ICollection<CatFamily> CatFamily { get; } = new List<CatFamily>();
    }
}
