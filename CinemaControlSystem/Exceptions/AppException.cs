namespace CinemaControlSystem.Exceptions
{
    public class AppException : Exception
    {
        /// <summary>
        /// Indicates whether the exception is critical.
        /// </summary>
        public bool IsCritical { get; set; }

        /// <summary>
        /// A list of error messages associated with the exception.
        /// </summary>
        public List<string> Errors { get; set; } = new List<string>();

        public AppException()
        {
        }

        public AppException(bool isCritical, List<string> errors)
        {
            IsCritical = isCritical;
            Errors = errors ?? new List<string>();
        }

        public AppException(string message)
            : base(message)
        {
        }

        public AppException(string message, bool isCritical)
            : base(message)
        {
            IsCritical = isCritical;
        }

        public AppException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public AppException(string message, Exception inner, bool isCritical)
            : base(message, inner)
        {
            IsCritical = isCritical;
        }

        public AppException(string message, bool isCritical, List<string> errors)
            : base(message)
        {
            IsCritical = isCritical;
            Errors = errors ?? new List<string>();
        }
    }
}
