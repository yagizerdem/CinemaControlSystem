namespace CinemaControlSystem.Utils
{
    public class SetTimeOut
    {
        public static void ExecuteAfterInterval(Action action, int timeout)
        {
            Thread t = new Thread(
                () =>
                {
                    Thread.Sleep(timeout);
                    action.Invoke();
                }
            );
            t.Start();
        }
    }
}
