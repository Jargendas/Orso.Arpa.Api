using System;

namespace Orso.Arpa.Domain.Entities
{
    public class MusicianProfileSection : BaseEntity
    {
        public MusicianProfileSection(Guid? id, MusicianProfile musicianProfile, Section section) : base(id)
        {
            MusicianProfile = musicianProfile;
            Section = section;
        }

        public MusicianProfileSection(Guid musicianProfileId, Guid sectionId)
        {
            MusicianProfileId = musicianProfileId;
            SectionId = sectionId;
        }

        public MusicianProfileSection()
        {
        }

        public Guid SectionId { get; private set; }
        public virtual Section Section { get; private set; }
        public Guid MusicianProfileId { get; private set; }
        public virtual MusicianProfile MusicianProfile { get; private set; }
    }
}