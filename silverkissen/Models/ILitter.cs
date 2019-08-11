using System;

namespace silverkissen.Models
{
    public interface ILitter
    {
        int AmountOfKids { get; set; }
        DateTime BirthDate { get; set; }
        bool Chipped { get; set; }
        int Id { get; set; }
        string Notes { get; set; }
        bool Pedigree { get; set; }
        string PedigreeName { get; set; }
        DateTime ReadyDate { get; set; }
        Litter.LitterStatus Status { get; set; }
        bool Vaccinated { get; set; }
    }
}