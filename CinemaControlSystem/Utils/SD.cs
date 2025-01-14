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
    

    }
}
