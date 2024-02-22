using Microsoft.AspNetCore.Components.Forms;
using System.Reflection.Emit;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace mission6_barney.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int MovieId { get; set; }

        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        [Required (ErrorMessage = "Sorry, you need to enter a Title")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Sorry, you need to enter a Year")]
        [Range(1888, 2050, ErrorMessage = "You must enter a valid date")]
        public int Year { get; set; } = 2024;
        public string? Director { get; set; }
        public string? Rating { get; set; }

        [Required(ErrorMessage = "Sorry, the Edited field is required")]
        public bool Edited { get; set; }
        public string? LentTo { get; set; }

        [Required(ErrorMessage = "Sorry, the CopiedToPlex field is required")]
        public bool CopiedToPlex { get; set; }
        public string? Notes { get; set; }
    }
}
