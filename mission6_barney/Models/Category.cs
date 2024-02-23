using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace mission6_barney.Models
{
    public class Category
    {
        [Key]
        //ForeignKey
        public required int CategoryId { get; set; }
        public required string CategoryName { get; set; }
    }
}
