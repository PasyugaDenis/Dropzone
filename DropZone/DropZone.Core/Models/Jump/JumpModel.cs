using System;

namespace DropZone.Core.Models
{
    public class JumpModel
    {
        public long Id { get; set; }

        public DateTime ModifiedAt { get; set; }

        public DateTime Date { get; set; }

        public string Task { get; set; }

        public double Height { get; set; }

        public double FallTime { get; set; }


        public long JumpBookId { get; set; }

        public long DropZoneId { get; set; }

        public long ParachuteSystemId { get; set; }

        public long AircraftId { get; set; }


        public JumpBookModel JumpBook { get; set; }

        public DropZoneModel DropZone { get; set; }

        public ParachuteSystemModel ParachuteSystem { get; set; }

        public AircraftModel Aircraft { get; set; }
    }
}
