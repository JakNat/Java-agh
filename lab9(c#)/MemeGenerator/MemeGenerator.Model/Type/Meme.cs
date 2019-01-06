using System;
using System.ComponentModel.DataAnnotations;

namespace MemeGenerator.Model.Type
{
    public class Meme
    {
        [Key]
        public int MemeId { get; set; }
        public string MemeTitle { get; set; }
        public byte[] Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedById { get; set; }
    }
}
