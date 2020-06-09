using System;

namespace DropZone.Database.Models
{
    public class Parachute : Entity
    {
        public string Shape { get; set; }

        public string Material { get; set; }

        public string SliderType { get; set; }

        public double Area { get; set; }

        public double LayingVolume { get; set; }

        public double Weight { get; set; }

        public double Height { get; set; }

        public double Scope { get; set; }

        public double Chord { get; set; }

        public double Incline { get; set; }

        public double ControlLineLength { get; set; }

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
