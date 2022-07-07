using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NotebookApplicationWeb.Models
{
    public class Category
    {   
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1,10)]
        public int DisplayOrder { get; set; }
        public ICollection<Note> Notes { get; set; }

    }
}
