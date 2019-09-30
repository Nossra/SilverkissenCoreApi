using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace silverkissen.Models.ViewModels
{
    public class AdminImageCatLitterViewModel
    {
        public int Id { get; set; } 
        public DateTime BirthDate { get; set; }
        public ICollection<AdminImageCatViewModel> Parents { get; set; } = new List<AdminImageCatViewModel>();
    }
}
