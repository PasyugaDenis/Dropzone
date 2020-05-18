using System;

namespace DropZone.Core.Models
{
    public class AADModel
    {
        public long Id { get; set; }

        public DateTime? MaintenanceDate { get; set; }

        public DateTime ModifiedAt { get; set; }


        public long AADTypeId { get; set; }

        public long HashBlockId { get; set; }


        public AADTypeModel AADType { get; set; }

        public HashBlockModel HashBlock { get; set; }

        public ParachuteSystemModel ParachuteSystem { get; set; }
    }
}
