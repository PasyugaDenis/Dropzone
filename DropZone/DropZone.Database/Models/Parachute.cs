using System;

namespace DropZone.Database.Models
{
    public class Parachute : Entity
    {
        public double Area { get; set; }

        public double LayingVolume { get; set; }

        public double Weight { get; set; }

        public int SectionCount { get; set; }

        public string Manufacturer { get; set; }

        public bool IsReserve { get; set; }

        public DateTime? LayingDate { get; set; }

        public DateTime? MaintenanceDate { get; set; }
    }
}
