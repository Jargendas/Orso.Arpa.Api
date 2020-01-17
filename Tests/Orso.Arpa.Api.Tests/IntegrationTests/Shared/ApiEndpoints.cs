using System;
using Orso.Arpa.Application.Dtos.Extensions;
using Orso.Arpa.Domain.Appointments;

namespace Orso.Arpa.Api.Tests.IntegrationTests.Shared
{
    public static class ApiEndpoints
    {
        private static string Base => "api";

        public static class AuthController
        {
            private static string Auth => $"{Base}/auth";

            public static string Login() => $"{Auth}/login";

            public static string Register() => $"{Auth}/register";

            public static string Password() => $"{Auth}/password";

            public static string SetRole() => $"{Auth}/role";
        }

        public static class UsersController
        {
            private static string Users => $"{Base}/users";

            public static string Get() => Users;

            public static string Delete(string username) => $"{Users}/{username}";
        }

        public static class RolesController
        {
            private static string Roles => $"{Base}/roles";

            public static string Get() => Roles;
        }

        public static class VenuesController
        {
            private static string Venues => $"{Base}/venues";

            public static string Get() => Venues;

            public static string GetRooms(Guid id) => $"{Venues}/{id}/rooms";
        }

        public static class SelectValuesController
        {
            public static string Get(string tableName, string propertyName) => $"{Base}/tables/{tableName}/properties/{propertyName}";
        }

        public static class SectionsController
        {
            private static string Sections => $"{Base}/sections";

            public static string Get() => Sections;
        }

        public static class ProjectsController
        {
            private static string Projects => $"{Base}/projects";

            public static string Get(bool includeCompleted = false) => $"{Projects}?includeCompleted={includeCompleted}";
        }

        public static class MeController
        {
            private static string Me => $"{Base}/users/me";

            public static string GetProfile() => $"{Me}/profile";

            public static string PutProfile() => $"{Me}/profile";
        }

        public static class RegionsController
        {
            private static string Regions => $"{Base}/regions";

            public static string Get() => Regions;

            public static string Post() => Regions;

            public static string Put(Guid id) => $"{Regions}/{id}";

            public static string Get(Guid id) => $"{Regions}/{id}";

            public static string Delete(Guid id) => $"{Regions}/{id}";
        }

        public static class AppointmentsController
        {
            private static string Appointments => $"{Base}/appointments";

            public static string Get(DateTime? date, DateRange range) => $"{Appointments}?date={date.Value.ToIsoString()}&range={range}";

            public static string Post() => Appointments;

            public static string Put(Guid id) => $"{Appointments}/{id}";

            public static string Get(Guid id) => $"{Appointments}/{id}";

            public static string AddRoom(Guid id, Guid roomId) => $"{Appointments}/{id}/rooms/{roomId}";

            public static string AddSection(Guid id, Guid sectionId) => $"{Appointments}/{id}/sections/{sectionId}";

            public static string AddProject(Guid id, Guid projectId) => $"{Appointments}/{id}/projects/{projectId}";

            public static string SetVenue(Guid id, Guid? venueId) => $"{Appointments}/{id}/venue/set/{venueId}";

            public static string SetDates(Guid id) => $"{Appointments}/{id}/dates/set";

            public static string Delete(Guid id) => $"{Appointments}/{id}";
        }
    }
}
