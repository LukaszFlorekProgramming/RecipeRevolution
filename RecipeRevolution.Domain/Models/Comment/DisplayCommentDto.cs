﻿namespace RecipeRevolution.Domain.Models.Comment
{
    public class DisplayCommentDto
    {
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
