using System;
using System.Collections.Generic;
using Orso.Arpa.Domain.Entities;
using Orso.Arpa.Domain.Logic.Venues;
using Orso.Arpa.Domain.Regions.Seed;

namespace Orso.Arpa.Tests.Shared.TestSeedData
{
    public static class VenueSeedData
    {
        public static IList<Venue> Venues
        {
            get
            {
                return new List<Venue>
                {
                    WeiherhofSchule
                };
            }
        }

        public static Venue WeiherhofSchule
        {
            get
            {
                return new Venue(
                    Guid.Parse("54eb30ff-6ea3-4026-8a49-5f149c8ec7e1"),
                    new Create.Command
                    {
                        Name = "Weiherhof Schule",
                        Address1 = "Schlüsselstraße 5",
                        Zip = "79104",
                        City = "Herdern",
                        Description = "Proberäume",
                        Country = "Deutschland",
                        UrbanDistrict = "Herdern",
                        RegionId = RegionSeedData.Freiburg.Id,
                        State = "Baden-Württemberg"
                    });
            }
        }
    }
}
