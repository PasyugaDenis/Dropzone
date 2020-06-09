using System.Collections.Generic;

namespace DropZone.Database.Models
{
    public class JumpBook : Entity
    {
        public string Category { get; set; }


        public long SportsmanId { get; set; }


        public virtual User Sportsman { get; set; }


        public virtual ICollection<Jump> Jumps { get; set; }
    }
}
