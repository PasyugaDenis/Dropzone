using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DropZone.Core.Models
{
    public class ParachuteSystemModel
    {
        public long Id { get; set; }

        public DateTime ModifiedAt { get; set; }


        public long MainParachuteId { get; set; }

        public long ReserveParachuteId { get; set; }

        public long AADId { get; set; }

        public long SatchelId { get; set; }

        public long UserId { get; set; }

        public long HashBlockId { get; set; }


        public ParachuteModel MainParachute { get; set; }

        public ParachuteModel ReserveParachute { get; set; }

        public AADModel AAD { get; set; }

        public SatchelModel Satchel { get; set; }

        public UserModel User { get; set; }

        public HashBlockModel HashBlock { get; set; }
    }
}
