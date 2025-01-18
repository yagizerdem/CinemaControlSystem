namespace CinemaControlSystem.Utils
{
    public class SD
    {
        /*
 
(?=.*[a-z]): At least one lowercase letter.
(?=.*[A-Z]): At least one uppercase letter.
(?=.*\d): At least one digit.
.{8,}: Minimum 8 characters.

 */
        public static string StrongPasswordRegex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$";

        public static string jwtissuer = "https://localhost/";
        public static string jwtaudiance = "https://localhost/";
        public static string authTokenName = "authToken";
        public static string anonimousProfileImage = "https://st2.depositphotos.com/5682790/10456/v/450/depositphotos_104564156-stock-illustration-male-user-icon.jpg";

        public static string[] FilmTypes = ["Horror", "Comedy", "Action", "Drama", "Science Fiction", "Romance"];


        public static string bossFirstName = "yagiz";
        public static string bossLastName = "erdem";
        public static string bossPassword= "12345aA!";
        public static string bossEmail = "yagize@gmail.com";
    }
}
