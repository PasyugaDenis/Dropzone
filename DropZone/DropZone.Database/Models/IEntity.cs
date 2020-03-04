using System;

namespace DropZone.Database.Models
{
    public interface IEntity
    {
        long Id { get; set; }

        DateTime ModifiedAt { get; set; }
    }
}
