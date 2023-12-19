using System.ComponentModel.DataAnnotations;

namespace lab5Dotnet_V2.Models
{
    public class Books
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string RealeseDate { get; set; }

    }
}
