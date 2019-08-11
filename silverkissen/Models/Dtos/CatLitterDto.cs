using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace silverkissen.Models.Dtos
{
    public class CatLitterDto : CatLitter
    {
        public new List<Image> Images { get; set; } = new List<Image>();
    }
}
