using System;

namespace Orso.Arpa.Domain.Entities
{
    public class RehearsalRoom : BaseEntity
    {
        public RehearsalRoom(Guid id) : base(id)
        {
        }

        public Guid RoomId { get; private set; }
        public virtual Room Room { get; private set; }
    }
}
