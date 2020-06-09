using System;

namespace DropZone.Core.Models
{
    public class HashBlockModel
    {
        public long Id { get; set; }

        public string Value { get; set; }

        public string Hash { get; set; }

        public string PreviousHash { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedAt { get; set; }


        public long UserId { get; set; }

        public long? PreviousHashBlockId { get; set; }


        public UserModel User { get; set; }

        public HashBlockModel PreviousHashBlock { get; set; }
    }
}
