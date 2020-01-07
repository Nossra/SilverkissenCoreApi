//using silverkissen.DbModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace silverkissen.Models
{
    public class CatLitter : Litter, ICatLitter
    { 
        public bool SVERAK { get; set; } 
        public ICollection<CatLitter_Parent> Parents { get; set; } = new List<CatLitter_Parent>();
        public ICollection<Cat> Kittens { get; set; } = new List<Cat>();
        public ICollection<CatLitter_Image> Images { get; set; } = new List<CatLitter_Image>(); 

        public CatLitter()
        {
        }

        public CatLitter(List<CatLitter_Image> images, List<CatLitter_Parent> parents)
        {
            this.Images = images;
            this.Parents = parents;
        }
    }
}
