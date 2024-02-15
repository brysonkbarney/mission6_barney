using Microsoft.AspNetCore.Components.Forms;
using System.Reflection.Emit;
using System;

namespace mission6_barney.Models
{
    public class Movie
    {
        public int MovieID { get; set; }
        public required string Category { get; set; }
        public required string Title { get; set; }
        public required string Year { get; set; }
        public required string Director { get; set; }
        public required string Rating { get; set; }
        public string? Edited { get; set; }
        public string? LentTo { get; set; }
        public string? Notes { get; set; }
    }
}
