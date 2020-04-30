using System;

namespace DropZone.Core.Models
{
    public class UserModel
    {
        public long Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public DateTime Birthday { get; set; }

        public DateTime ModifiedAt { get; set; }


        public long RoleId { get; set; }

        public long? DropZoneId { get; set; }


        public RoleModel Role { get; set; }

        public DropZoneModel DropZone { get; set; }
    }
}
