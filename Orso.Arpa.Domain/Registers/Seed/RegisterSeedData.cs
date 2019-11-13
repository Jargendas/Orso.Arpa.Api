using System;
using System.Collections.Generic;
using Orso.Arpa.Domain.Entities;

namespace Orso.Arpa.Domain.Registers.Seed
{
    public static class RegisterSeedData
    {
        public static IList<Register> Registers
        {
            get
            {
                return new List<Register>
                {
                    Choir,
                    Orchestra,
                    Soloists,
                    Other,
                    Miscellaneous,
                    FemaleVoices,
                    MaleVoices,
                    DeepFemaleVoices,
                    HighFemaleVoices,
                    DeepMaleVoices,
                    HighMaleVoices,
                    Alto,
                    Alto1,
                    Alto2,
                    Soprano,
                    Soprano1,
                    Soprano2,
                    Tenor,
                    Tenor1,
                    Tenor2,
                    Basso,
                    Basso1,
                    Basso2,
                    WindSection,
                    Strings,
                    Percussion,
                    Woodwind,
                    Brass
                };
            }
        }

        public static Register Choir
        {
            get
            {
                return new Register(Guid.Parse("c2cfb7a0-4981-4dda-b988-8ba74957f6a4"), "Choir", null);
            }
        }

        public static Register Orchestra
        {
            get
            {
                return new Register(Guid.Parse("308659d6-6014-4d2c-a62a-be75bf202e62"), "Orchestra", null);
            }
        }

        public static Register Soloists
        {
            get
            {
                return new Register(Guid.Parse("e0fdb057-c9b7-4477-be75-cbf920a26af6"), "Soloist", null);
            }
        }

        public static Register Other
        {
            get
            {
                return new Register(Guid.Parse("c9403ca4-6b75-44c3-b567-e53bbd78fb75"), "Other", null);
            }
        }

        public static Register Miscellaneous
        {
            get
            {
                return new Register(Guid.Parse("a19fa9af-dcba-48e3-bc21-be2130fa528c"), "Miscellaneous", null);
            }
        }

        public static Register FemaleVoices
        {
            get
            {
                return new Register(Guid.Parse("3ed0960c-1eed-4a45-a1ef-343aa8e7b2d6"), "Female Voices", Choir.Id);
            }
        }

        public static Register MaleVoices
        {
            get
            {
                return new Register(Guid.Parse("4599103d-f220-4744-92d1-7c6993e9bda4"), "Male Voices", Choir.Id);
            }
        }

        public static Register DeepFemaleVoices
        {
            get
            {
                return new Register(Guid.Parse("48337b78-70f0-493e-911b-296632b06ef8"), "Deep Female Voices", FemaleVoices.Id);
            }
        }

        public static Register HighFemaleVoices
        {
            get
            {
                return new Register(Guid.Parse("5d469fc5-b3e6-40b8-9fa9-542981083ce3"), "High Female Voices", FemaleVoices.Id);
            }
        }

        public static Register DeepMaleVoices
        {
            get
            {
                return new Register(Guid.Parse("b9673cfd-7cdb-472c-86e0-1304cbb3840a"), "Deep Male Voices", MaleVoices.Id);
            }
        }

        public static Register HighMaleVoices
        {
            get
            {
                return new Register(Guid.Parse("7924daef-2542-4648-a42f-4c4374ee09db"), "High Male Voices", MaleVoices.Id);
            }
        }

        public static Register Alto
        {
            get
            {
                return new Register(Guid.Parse("a06431be-f9d6-44dc-8fdb-fbf8aa2bb940"), "Alto", DeepFemaleVoices.Id);
            }
        }

        public static Register Soprano
        {
            get
            {
                return new Register(Guid.Parse("7daa1394-a70d-4a24-88a6-ccf511d75c4d"), "Soprano", HighFemaleVoices.Id);
            }
        }

        public static Register Basso
        {
            get
            {
                return new Register(Guid.Parse("e7dd10ef-1c39-4440-9a6c-65d397f010ca"), "Basso", DeepMaleVoices.Id);
            }
        }

        public static Register Tenor
        {
            get
            {
                return new Register(Guid.Parse("1579d7e7-4f55-4532-a078-69fd1ec939da"), "Tenor", HighMaleVoices.Id);
            }
        }

        public static Register Alto1
        {
            get
            {
                return new Register(Guid.Parse("e809ee90-23f9-44de-b80e-2fddd5ee3683"), "Alto 1", Alto.Id);
            }
        }

        public static Register Alto2
        {
            get
            {
                return new Register(Guid.Parse("50dfa2be-85e2-4638-aa53-22dadc97a844"), "Alto 2", Alto.Id);
            }
        }

        public static Register Soprano1
        {
            get
            {
                return new Register(Guid.Parse("8470ddf0-43ab-477e-b3bc-47ede014b359"), "Soprano 1", Soprano.Id);
            }
        }

        public static Register Soprano2
        {
            get
            {
                return new Register(Guid.Parse("22d7cf92-7b29-4cf1-a6fa-2954377589b4"), "Soprano 2", Soprano.Id);
            }
        }

        public static Register Tenor1
        {
            get
            {
                return new Register(Guid.Parse("3db46ff0-9165-46cc-8f28-6a1d52dee518"), "Tenor 1", Tenor.Id);
            }
        }

        public static Register Tenor2
        {
            get
            {
                return new Register(Guid.Parse("afef89cf-90e1-4d4f-83ab-d2b47e97af0f"), "Tenor 2", Tenor.Id);
            }
        }

        public static Register Basso1
        {
            get
            {
                return new Register(Guid.Parse("bfe0e1ca-95ce-4cb6-a9c9-3c23c70bab21"), "Basso 1", Basso.Id);
            }
        }

        public static Register Basso2
        {
            get
            {
                return new Register(Guid.Parse("61fa66ec-3103-43fe-800c-930547dff82c"), "Basso 2", Basso.Id);
            }
        }

        public static Register WindSection
        {
            get
            {
                return new Register(Guid.Parse("b289cfe7-d66e-48d8-83a9-f4b1f7710863"), "Wind Section", Orchestra.Id);
            }
        }

        public static Register Strings
        {
            get
            {
                return new Register(Guid.Parse("1bde9862-3ed5-45cd-8d80-0a52c6b4c0fb"), "Strings", Orchestra.Id);
            }
        }

        public static Register Percussion
        {
            get
            {
                return new Register(Guid.Parse("0558a5ff-ee27-44a1-82ab-d0c0cc018c3c"), "Percussion", Orchestra.Id);
            }
        }

        public static Register Woodwind
        {
            get
            {
                return new Register(Guid.Parse("a6abdeec-8185-40ac-a418-2e422bb9adbd"), "Woodwind", WindSection.Id);
            }
        }

        public static Register Brass
        {
            get
            {
                return new Register(Guid.Parse("f4c70178-d069-44dc-8956-7160c5fef52e"), "Brass", WindSection.Id);
            }
        }
    }
}
