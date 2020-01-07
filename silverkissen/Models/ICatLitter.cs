using System.Collections.Generic;

namespace silverkissen.Models
{
    public interface ICatLitter
    {
        ICollection<CatLitter_Image> Images { get; set; }
        ICollection<Cat> Kittens { get; set; }
        ICollection<CatLitter_Parent> Parents { get; set; }
        bool SVERAK { get; set; } 
    }
}