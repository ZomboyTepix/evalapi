using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvalApi.Src.Core.Repositories.Entities
{
    [Table("Posts")]
    public class PostEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 

        [Required]
        public int UserId { get; set; } 

        [Required]
        [MinLength(1)]
        public string Title { get; set; } = null!; 

        [Required]
        [MinLength(1)]
        public string Body { get; set; } = null!; 
    }
}
