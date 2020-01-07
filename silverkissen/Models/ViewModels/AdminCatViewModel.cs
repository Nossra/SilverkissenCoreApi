using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace silverkissen.Models.ViewModels
{
    public class CatViewModel : Cat
    { 
        public new ICollection<Image> Images { get; set; } = new List<Image>();
    }
}
