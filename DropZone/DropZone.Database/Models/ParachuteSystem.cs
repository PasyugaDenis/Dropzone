namespace DropZone.Database.Models
{
    public class ParachuteSystem : Entity
    {
        public long MainParachuteId { get; set; }

        public long ReserveParachuteId { get; set; }

        public long AADId { get; set; }

        public long SatchelId { get; set; }

        public long UserId { get; set; }

        public long HashBlockId { get; set; }


        public virtual Parachute MainParachute { get; set; }

        public virtual Parachute ReserveParachute { get; set; }

        public virtual AAD AAD { get; set; }

        public virtual Satchel Satchel { get; set; }

        public virtual User User { get; set; }

        public virtual HashBlock HashBlock { get; set; }
    }
}
