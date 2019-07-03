using System.Collections.Generic;
using silverkissen.DbModels;

namespace silverkissen.Models
{
    public interface IImage
    {
        ICollection<CatImages> CatImages { get; }
        ICollection<CatLitterImages> CatLitter { get; }
        string Filename { get; set; }
        string Filetype { get; set; }
        int Id { get; set; }
        string Value { get; set; }
    }
}