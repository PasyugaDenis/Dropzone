using System;

namespace DropZone.Database.Models
{
    public class Parachute : Entity
    {
        public double Area { get; set; }

        public double LayingVolume { get; set; }

        public double Weight { get; set; }

        public int LayingCount { get; set; }

        public int SectionCount { get; set; }
       
        public bool IsReserve { get; set; }

        public DateTime? LayingDate { get; set; }

        public DateTime? MaintenanceDate { get; set; }


        public long ManufacturerId { get; set; }

        public long HashBlockId { get; set; }


        public virtual Manufacturer Manufacturer { get; set; }

        public virtual HashBlock HashBlock { get; set; }
    }
}
