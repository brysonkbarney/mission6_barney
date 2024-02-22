using System.ComponentModel.DataAnnotations;

namespace mission6_barney.Models
{
    public class Category
    {
        [Key]
        public required int CategoryId { get; set; }
        public required string CategoryName { get; set; }
    }
}
