using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace silverkissen.Models
{
    public class CatLitter_Image
    {
        public int CatLitterId { get; set; } 
        public int ImageId { get; set; }

        public CatLitter_Image()
        {

        }

        public CatLitter_Image(int litterId, int imageId)
        {
            CatLitterId = litterId;
            ImageId = imageId;
        }
    }
}