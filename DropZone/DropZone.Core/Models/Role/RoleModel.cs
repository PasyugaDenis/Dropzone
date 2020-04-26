using System;
using System.Collections.Generic;

namespace DropZone.Core.Models
{
    public class RoleModel
    {
        public long Id { get; set; }

        public string Value { get; set; }

        public DateTime ModifiedAt { get; set; }


        public List<UserModel> Users { get; set; }
    }
}
