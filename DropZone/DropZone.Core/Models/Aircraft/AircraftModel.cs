using System;

namespace DropZone.Core.Models
{
    public class AircraftModel
    {
        public long Id { get; set; }

        public string Type { get; set; }

        public int Capacity { get; set; }

        public bool IsAvailable { get; set; }

        public DateTime ModifiedAt { get; set; }


        public long DropZoneId { get; set; }


        public DropZoneModel DropZone { get; set; }
    }
}
