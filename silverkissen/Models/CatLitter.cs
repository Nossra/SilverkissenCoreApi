using silverkissen.DbModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace silverkissen.Models
{
    public class CatLitter : Litter
    { 
        public bool SVERAK { get; set; } 
        public ICollection<CatFamily> CatFamily { get; } = new List<CatFamily>();
        public ICollection<CatLitterImages> LitterImages { get; } = new List<CatLitterImages>();
    }
}
