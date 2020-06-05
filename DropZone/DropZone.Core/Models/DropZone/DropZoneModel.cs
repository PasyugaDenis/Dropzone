using System;
using System.Collections.Generic;

namespace DropZone.Core.Models
{
    public class DropZoneModel
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string Country { get; set; }

        public string RunwayType { get; set; }

        public double RunwayLength { get; set; }

        public double Square { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public DateTime RegistrationDate { get; set; }

        public DateTime ModifiedAt { get; set; }


        public List<AircraftModel> Aircrafts { get; set; }

        public List<UserModel> Users { get; set; }
    }
}
