using System;

namespace DropZone.Database.Models
{
    public class AAD : Entity
    {
        public string Name { get; set; }

        public double Height { get; set; }

        public double Speed { get; set; }

        public DateTime? MaintenanceDate { get; set; }


        public long ManufacturerId { get; set; }

        public long HashBlockId { get; set; }

        
        public virtual Manufacturer Manufacturer { get; set; }

        public virtual HashBlock HashBlock { get; set; }

        public virtual ParachuteSystem ParachuteSystem { get; set; }
    }
}
