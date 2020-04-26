using System;

namespace DropZone.Database.Models
{
    public class Satchel : Entity
    {
        public double MainParachuteArea { get; set; }

        public double ReserveParachuteArea { get; set; }

        public DateTime? MaintenanceDate { get; set; }


        public long Manufacturerid { get; set; }

        public long HashBlockId { get; set; }

        
        public virtual Manufacturer Manufacturer { get; set; }

        public virtual HashBlock HashBlock { get; set; }

        public virtual ParachuteSystem ParachuteSystem { get; set; }
    }
}
