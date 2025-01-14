using CinemaControlSystem.Exceptions;

namespace CinemaControlSystem.Models
{
    public class ServiceResponse<T>
    {
        public T Data { get; set; }
        public bool isSuccess { get; set; }
        public string? Message { get; set; }
        public IEnumerable<string> ErrorMessages { get; set; } = Enumerable.Empty<string>();   

        public static ServiceResponse<T> Success<T>(T Data , string? Message = null)
        {
            ServiceResponse<T> response = new ServiceResponse<T>();
            response.isSuccess = true;
            response.Data = Data;
            response.Message = Message;

            return response;
        }

        public static ServiceResponse<T> Fail(T Data, string? Message = null)
        {
            ServiceResponse<T> response = new ServiceResponse<T>();
            response.isSuccess = false;
            response.Data = Data;
            response.Message = Message;

            return response;
        }

        public static ServiceResponse<T> Fail(T Data, IEnumerable<string> exceptions, string? Message = null)
        {
            ServiceResponse<T> response = new ServiceResponse<T>();
            response.isSuccess = false;
            response.Data = Data;
            response.Message = Message;
            response.ErrorMessages = exceptions;    

            return response;
        }

        public static ServiceResponse<T> Fail(string? Message = null)
        {
            ServiceResponse<T> response = new ServiceResponse<T>();
            response.isSuccess = false;
            response.Message = Message;

            return response;
        }

    }
}
