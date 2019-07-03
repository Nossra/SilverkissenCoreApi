using silverkissen.DbModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace silverkissen.Models
{
    public class Image : IImage
    {
        [Key]
        public int Id { get; set; }
        public string Filename { get; set; }
        public string Filetype { get; set; }
        public string Value { get; set; }
        public ICollection<CatLitterImages> CatLitter { get; } = new List<CatLitterImages>();
        public ICollection<CatImages> CatImages { get; } = new List<CatImages>();
    }
}
