﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeRevolution.Domain.Entities
{
    public class Image
    {
        public int ImageId { get; set; }
        public string FileName { get; set; }
        public byte[] Data { get; set; }
        public string ContentType { get; set; }
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}
