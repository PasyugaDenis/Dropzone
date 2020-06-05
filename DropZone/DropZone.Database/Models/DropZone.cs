using System;
using System.Collections.Generic;

namespace DropZone.Database.Models
{
    public class DropZone : Entity
    {
        public string Title { get; set; }

        public string Country { get; set; }

        public string RunwayType { get; set; }

        public double RunwayLength { get; set; }

        public double Square { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public DateTime RegistrationDate { get; set; } 


        public virtual ICollection<Aircraft> Aircrafts { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
