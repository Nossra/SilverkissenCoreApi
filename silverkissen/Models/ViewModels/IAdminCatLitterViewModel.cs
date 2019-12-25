using System.Collections.Generic;

namespace silverkissen.Models.ViewModels
{
    public interface ICatLitterViewModel
    {
        ICollection<Cat> Parents { get; set; }
        ICollection<Image> Images { get; set; }
    }
}