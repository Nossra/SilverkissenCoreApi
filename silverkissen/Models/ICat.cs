using System.Collections.Generic;

namespace silverkissen.Models
{
    public interface ICat
    {
        bool Chipped { get; set; }
        ICollection<Cat_Image> Images { get; set; } 
        bool Pedigree { get; set; }
        bool Vaccinated { get; set; }
    }
}