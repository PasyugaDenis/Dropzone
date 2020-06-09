using System;

namespace DropZone.Database.Models
{
    public class Jump : Entity
    {
        public DateTime Date { get; set; }

        public string Task { get; set; }

        public double Height { get; set; }

        public double FallTime { get; set; }


        public long JumpBookId { get; set; }

        public long DropZoneId { get; set; }

        public long ParachuteSystemId { get; set; }

        public long AircraftId { get; set; }


        public virtual JumpBook JumpBook { get; set; }

        public virtual DropZone DropZone { get; set; }

        public virtual ParachuteSystem ParachuteSystem { get; set; }

        public virtual Aircraft Aircraft { get; set; }
    }
}
