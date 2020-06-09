using System.Collections.Generic;

namespace DropZone.Database.Models
{
    //SuperAdmin
    //Admin
    //Manager
    //Layer
    //Sportsman
    public class Role : Entity
    {
        public string Value { get; set; }


        public virtual ICollection<User> Users { get; set; }
    }
}
