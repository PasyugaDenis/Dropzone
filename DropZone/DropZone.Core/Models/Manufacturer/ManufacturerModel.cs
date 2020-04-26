using System;

namespace DropZone.Core.Models
{
    public class ManufacturerModel
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string Country { get; set; }

        public DateTime ModifiedAt { get; set; }
    }
}
