using System;
using Orso.Arpa.Domain.Enums;
using Orso.Arpa.Domain.Logic.ContactDetails;

namespace Orso.Arpa.Domain.Entities
{
    public class ContactDetail : BaseEntity
    {
        public ContactDetail(Guid? id, Create.Command command) : base(id)
        {
            Key = command.Key;
            Value = command.Value;
            TypeId = command.TypeId;
            CommentTeam = command.CommentTeam;
            Preference = command.Preference;
            PersonId = command.PersonId;
        }
        protected ContactDetail() { }

        public ContactDetailKey Key { get; private set; }
        public string Value { get; private set; }
        public Guid? TypeId { get; private set; }
        public virtual SelectValueMapping Type { get; private set; }
        public string CommentInner { get; private set; }
        public string CommentTeam { get; private set; }
        public byte Preference { get; private set; }
        public Guid PersonId { get; private set; }
        public virtual Person Person { get; private set; }
    }
}
