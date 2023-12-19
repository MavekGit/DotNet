using System.ComponentModel.DataAnnotations;

namespace lab5Dotnet.Models
{
    public class Library
    {

        public int Id { get; set; }
        public string? Title { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        
        public string Author { get; set; }

    }
}
