using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Upload_Download_Api.Attributes;

namespace NotebookApplicationWeb.Models
{
    public class Note
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        public string Title { get; set; }

        [MaxFileSize(5 * 1024 * 1024)]
        [AllowedExtension(new string[] { ".png", ".jpg" })]
        [NotMapped]
        public IFormFile Image { get; set; }
        public byte[] ImageBytes { get; set; }
        public Category Category { get; set; }
        [NotMapped]
        public int IdForQuery { get; set; }


    }
}
