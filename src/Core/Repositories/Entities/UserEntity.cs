using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvalApi.Src.Core.Repositories.Entities
{
    [Table("Users")]
    public class UserEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        public string Name { get; set; } = null!;

        [Required]
        [MinLength(1)]
        public string Username { get; set; } = null!;

        [Required]
        [MinLength(1)]
        [EmailAddress]
        public string Email { get; set; } = null!;
    }
}
