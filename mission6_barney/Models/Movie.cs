// Necessary namespaces for data annotation attributes, form components, and system utilities.
using Microsoft.AspNetCore.Components.Forms;
using System.Reflection.Emit; // This appears to be unused and could potentially be removed.
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace mission6_barney.Models
{
    // Declaration of the Movie class.
    public class Movie
    {
        // The primary key of the Movie entity. This field is required.
        [Key]
        [Required]
        public int MovieId { get; set; }

        // Foreign key relation to the Category entity. It's nullable, indicating a movie might not be associated with a category.
        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }
        // Navigation property for the Category entity. Allows for lazy loading of the related Category entity.
        public Category? Category { get; set; }

        // Required attribute specifies that the Title field cannot be null. Custom error message provided for user feedback.
        [Required(ErrorMessage = "Sorry, you need to enter a Title")]
        public string Title { get; set; } = string.Empty;

        // The Year property must be within the range 1888 to 2050, inclusive. Custom error messages are specified.
        [Required(ErrorMessage = "Sorry, you need to enter a Year")]
        [Range(1888, 2050, ErrorMessage = "You must enter a valid date")]
        public int Year { get; set; } = 2024;

        // Optional properties for Director, Rating, LentTo, and Notes. These can be null.
        public string? Director { get; set; }
        public string? Rating { get; set; }

        // Boolean properties for Edited and CopiedToPlex, with Required attribute to ensure they are explicitly set.
        [Required(ErrorMessage = "Sorry, the Edited field is required")]
        public bool Edited { get; set; }

        public string? LentTo { get; set; }

        [Required(ErrorMessage = "Sorry, the CopiedToPlex field is required")]
        public bool CopiedToPlex { get; set; }

        // Notes about the movie. It's an optional field.
        public string? Notes { get; set; }
    }
}
