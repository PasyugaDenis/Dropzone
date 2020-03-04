using System;

namespace DropZone.Database.Models
{
    public class Satchel : Entity
    {
        public double MainParachuteArea { get; set; }

        public double ReserveParachuteArea { get; set; }

        public string Manufacturer { get; set; }

        public DateTime? MaintenanceDate { get; set; }


        public virtual ParachuteSystem ParachuteSystem { get; set; }
    }
}
