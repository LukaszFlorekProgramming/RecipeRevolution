﻿using RecipeRevolution.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeRevolution.Application.Interfaces
{
    public interface IImageService
    {
        public ImageDto GetById(int id);
        public int Create(ImageDto imageDto);
    }
}
