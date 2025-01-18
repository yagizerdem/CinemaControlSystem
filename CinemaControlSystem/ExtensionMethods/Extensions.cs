using Microsoft.AspNetCore.Components;

namespace CinemaControlSystem.ExtensionMethods
{
    public static class Extensions
    {
        public static MarkupString AsMarkup(this string s) => (MarkupString)s;
    }
}
