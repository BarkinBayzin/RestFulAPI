﻿namespace RestFulAPI.Models.DTOs
{
    public class GetCategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
    }
}
