using System;

namespace DropZone.Core.Models
{
    public class AADModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public double Height { get; set; }

        public double Speed { get; set; }

        public DateTime? MaintenanceDate { get; set; }

        public DateTime ModifiedAt { get; set; }


        public long ManufacturerId { get; set; }

        public long HashBlockId { get; set; }


        public ManufacturerModel Manufacturer { get; set; }

        public HashBlockModel HashBlock { get; set; }

        public ParachuteSystemModel ParachuteSystem { get; set; }
    }
}
