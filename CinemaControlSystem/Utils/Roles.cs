using Microsoft.AspNetCore.Http;

namespace CinemaControlSystem.Utils
{
    // convert roles to string while seeding to database 
    public static class Roles
    {
        public const string Client = "Client";
        public const string IT = "IT";
        public const string Boss = "Boss";
        public const string DepartmentManager = "DepartmentManager";
        public const string Doorsman = "Doorsman";
    }
}
