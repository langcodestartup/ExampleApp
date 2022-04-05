namespace TestBlazorApp.Server.Service
{
    public class TestService
    {
        StreamReader reader;

        public TestService()
        {
            
        }

        public void TestMethod()
        {
            this.reader = new StreamReader("hello.txt");
            string msg = reader.ReadToEnd();
            Console.WriteLine(msg);
        }
    }
}
