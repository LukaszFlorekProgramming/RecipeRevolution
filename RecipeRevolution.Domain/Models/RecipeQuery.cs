﻿namespace RecipeRevolution.Domain.Models
{
    public class RecipeQuery
    {
        public string SearchPhrase { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
