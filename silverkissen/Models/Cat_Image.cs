using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace silverkissen.Models
{
    public class Cat_Image
    {
        public int CatId { get; set; }
        public int ImageId { get; set; }

        public Cat_Image()
        {

        }
        public Cat_Image(int catid, int imageid)
        {
            CatId = catid;
            ImageId = imageid;
        }
    }
}
