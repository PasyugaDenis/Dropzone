using System;

namespace DropZone.Database.Models
{
    public class User : Entity
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public DateTime Birthday { get; set; }


        public long RoleId { get; set; }

        public long? DropZoneId { get; set; }


        public virtual Role Role { get; set; }

        public virtual DropZone DropZone { get; set; }
    }
}
