namespace DropZone.Database.Models
{
    public class Aircraft : Entity
    {
        public string Type { get; set; }

        public int Capacity { get; set; }

        public bool IsAvailable { get; set; }


        public long DropZoneId { get; set; }

        
        public virtual DropZone DropZone { get; set; }
    }
}
