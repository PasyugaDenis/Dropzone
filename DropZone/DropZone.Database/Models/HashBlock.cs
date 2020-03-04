using System;

namespace DropZone.Database.Models
{
    public class HashBlock : Entity
    {
        public string Value { get; set; }

        public string Hash { get; set; }

        public string PreviousHash { get; set; }

        public DateTime CreatedOn { get; set; }


        public long UserId { get; set; }

        public long? PreviousHashId { get; set; }


        public virtual User User { get; set; }

        public virtual HashBlock PreviousHashBlock { get; set; }
    }
}
