using System;

namespace DropZone.Core.Models
{
    public class SatchelModel
    {
        public long Id { get; set; }

        public double MainParachuteArea { get; set; }

        public double ReserveParachuteArea { get; set; }

        public DateTime? MaintenanceDate { get; set; }

        public DateTime ModifiedAt { get; set; }


        public long Manufacturerid { get; set; }

        public long HashBlockId { get; set; }


        public ManufacturerModel Manufacturer { get; set; }

        public HashBlockModel HashBlock { get; set; }

        public ParachuteSystemModel ParachuteSystem { get; set; }
    }
}
