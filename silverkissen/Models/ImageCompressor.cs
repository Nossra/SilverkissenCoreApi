using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace silverkissen.Models
{
    public class ImageCompressor : IImageCompression
    {
        public string CompressImage(string ImageValue)
        {
            Chilkat.Compression compress = new Chilkat.Compression();
            compress.Algorithm = "deflate";
            Chilkat.BinData binDat = new Chilkat.BinData();
            binDat.AppendEncoded(ImageValue, "base64");
            compress.CompressBd(binDat);

            return binDat.GetEncoded("base64");
        }

        public string DecompressImage(string ImageValue)
        {
            Chilkat.Compression compress = new Chilkat.Compression();
            Chilkat.BinData binDat = new Chilkat.BinData();
            binDat.AppendEncoded(ImageValue, "base64");
            compress.DecompressBd(binDat);

            return binDat.GetEncoded("base64");
        }
    }
}
