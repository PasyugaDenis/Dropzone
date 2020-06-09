using System;

namespace DropZone.Core.Models
{
    public class AADTypeModel
    {
        public long Id { get; set; }

        public string Type { get; set; }

        public double Height { get; set; }

        public double Speed { get; set; }

        public DateTime ModifiedAt { get; set; }


        public long ManufacturerId { get; set; }


        public ManufacturerModel Manufacturer { get; set; }
    }
}
