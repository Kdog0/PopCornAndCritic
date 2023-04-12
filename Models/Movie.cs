﻿using TarefasSistemas.Enums;

namespace TarefasSistemas.Models
{
    public class Movie
    {   
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ImgUrl { get; set; }
        public string? Duration { get; set; }
        public string? Genre { get; set; }
        public double? Rating { get; set; }

    }
}
