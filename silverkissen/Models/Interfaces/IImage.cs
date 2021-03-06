﻿using System.Collections.Generic;

namespace silverkissen.Models
{
    public interface IImage
    { 
        string Filename { get; set; }
        string Filetype { get; set; }
        int Id { get; set; }
        string Value { get; set; }
        bool DisplayPicture { get; set; }
    }
}