using System.ComponentModel.DataAnnotations;

namespace NotebookApplicationWeb.Models
{
    public class User
    {
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        [Key]
        public Guid UserId { get; set; }
        ICollection<Note> Notes { get; set; }
    }
}
