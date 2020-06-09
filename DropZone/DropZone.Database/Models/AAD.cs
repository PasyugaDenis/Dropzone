using System;

namespace DropZone.Database.Models
{
    public class AAD : Entity
    {
        public DateTime? MaintenanceDate { get; set; }


        public long AADTypeId { get; set; }

        public long HashBlockId { get; set; }

        
        public virtual AADType AADType { get; set; }

        public virtual HashBlock HashBlock { get; set; }
    }
}
