using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace silverkissen.Models.ViewModels
{
    public class AdminImageViewModel : Image
    {
        public ICollection<AdminImageCatLitterViewModel> CatLitters { get; set; } = new List<AdminImageCatLitterViewModel>();
        public ICollection<AdminImageCatViewModel> CatParents { get; set; } = new List<AdminImageCatViewModel>();
    }
}
