using System;

namespace DropZone.Core.Models
{
    public class ParachuteModel
    {
        public long Id { get; set; }

        public double Area { get; set; }

        public double LayingVolume { get; set; }

        public double Weight { get; set; }

        public int LayingCount { get; set; }

        public int SectionCount { get; set; }

        public bool IsReserve { get; set; }

        public DateTime? LayingDate { get; set; }

        public DateTime? MaintenanceDate { get; set; }

        public DateTime ModifiedAt { get; set; }


        public long ManufacturerId { get; set; }

        public long HashBlockId { get; set; }


        public ManufacturerModel Manufacturer { get; set; }

        public HashBlockModel HashBlock { get; set; }
    }
}
