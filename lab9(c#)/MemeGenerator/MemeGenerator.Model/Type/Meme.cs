using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MemeGenerator.Model.Type
{
    public class Meme
    {
        [Key]
        public int MemeId { get; set; }
        public string Title { get; set; }
        public byte[] Content { get; set; }
        public DateTime CreatedDate { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
