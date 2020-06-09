using System;
using System.Collections.Generic;

namespace DropZone.Core.Models
{
    public class JumpBookModel
    {
        public long Id { get; set; }

        public string Category { get; set; }

        public DateTime ModifiedAt { get; set; }


        public long SportsmanId { get; set; }


        public UserModel Sportsman { get; set; }


        public List<JumpModel> Jumps { get; set; }
    }
}
