using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MemeGenerator.Model.Type
{
    public class Meme
    {
        [Key]
        public int Id { get; set; }
        public string MemeTitle { get; set; }
        public byte[] Content { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
