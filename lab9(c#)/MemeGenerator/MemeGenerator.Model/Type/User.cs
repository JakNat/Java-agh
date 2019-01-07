using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeGenerator.Model.Type
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(450)]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public DateTime? CreatedDate { get; set; }
        public ICollection<Meme> Memes { get; set; }
    }
}
