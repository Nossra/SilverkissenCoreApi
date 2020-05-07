using Microsoft.Extensions.Configuration;
using silverkissen.Models;
using silverkissen.Models.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace silverkissen.Utilities
{
    public static class ModelFactory
    {
        public static IImage NewImage()
        {
            return new Image();
        } 

        public static IUser NewUser(string username, string password)
        {
            return new User(username,password);
        }

        public static ITokenIssuer NewTokenIssuer(IConfiguration Configuration)
        {
            return new TokenIssuer(Configuration);
        }

        public static ICat NewCat()
        {
            return new Cat();
        }
       
        public static ICatLitterViewModel NewAdminCatLitterViewModel()
        {
            return new CatLitterViewModel();
        }

        public static ICatLitter NewCatLitter()
        {
            return new CatLitter();
        }

        public static ICatLitter NewCatLitter(List<Image> images, List<CatLitter_Parent> parents)
        { 
            List<CatLitter_Image> catlitter_imageList = new List<CatLitter_Image>();
            return new CatLitter(catlitter_imageList, parents);
        }

        public static IImageCompression NewImageCompressor()
        {
            return new ImageCompressor();
        }
    }
}
