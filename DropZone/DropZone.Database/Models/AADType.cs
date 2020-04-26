namespace DropZone.Database.Models
{
    public class AADType : Entity
    {
        public string Type { get; set; }

        public double Height { get; set; }

        public double Speed { get; set; }


        public long ManufacturerId { get; set; }


        public virtual Manufacturer Manufacturer { get; set; }
    }
}
