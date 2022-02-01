namespace TestNinja.Mocking
{
    public class Program
    {
        public static void Main()
        {
            VideoService service = new VideoService();
            string title = service.ReadVideoTitle();
        }
    }
}