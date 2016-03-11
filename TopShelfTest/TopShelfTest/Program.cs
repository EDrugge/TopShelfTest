using Topshelf;

namespace TopShelfTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<TopShelfWorker>(s =>
                {
                    s.ConstructUsing(name => new TopShelfWorker());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
                x.RunAsLocalSystem();

                x.SetDescription("Topshelf Test");
                x.SetDisplayName("TopShelf Test");
                x.SetServiceName("TopShelf service");
            });
        }
    }
}