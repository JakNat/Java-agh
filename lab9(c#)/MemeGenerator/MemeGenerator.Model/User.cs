using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeGenerator.Model
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [Index(IsUnique = true)]
        [StringLength(450)]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
