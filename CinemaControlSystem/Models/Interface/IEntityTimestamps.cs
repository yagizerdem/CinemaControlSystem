namespace CinemaControlSystem.Models.Interface
{
    public interface IEntityTimestamps
    {
        DateTime CreatedDate { get; set; }
        DateTime UpdatedDate { get; set; }
    }
}
