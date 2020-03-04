using System;
using System.ComponentModel.DataAnnotations;

namespace DropZone.Database.Models
{
    public class Entity : IEntity
    {
        [Key]
        public long Id { get; set; }

        public DateTime ModifiedAt { get; set; }
    }
}
