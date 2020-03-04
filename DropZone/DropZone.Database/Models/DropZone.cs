using System.Collections.Generic;

namespace DropZone.Database.Models
{
    public class DropZone : Entity
    {
        public string Title { get; set; }

        public string Location { get; set; }

        public string Country { get; set; }


        public virtual ICollection<Aircraft> Aircrafts { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
