using DropZone.Core.Models;

namespace DropZone.API.Models
{
    public class CreateDropZoneModel
    {
        public string AdminEmail { get; set; }

        public DropZoneModel DropZone { get; set; }
    }
}