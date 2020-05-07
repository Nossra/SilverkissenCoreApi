using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace silverkissen.Models
{
    public interface IImageCompression
    {
        string CompressImage(string ImageValue);
        string DecompressImage(string ImageValue);
    }
}
