using System.ComponentModel.DataAnnotations;

namespace LabolatoriumDotNetNr5.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Author { get; set; }
        public DateTime ReleaseDate { get; set; }
        
    }
}
