using ConsoleActionRR;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var consoleAction = new ConsoleAction();
            consoleAction.Add("1", "以Received委托接收", RunClientForReceived);
            consoleAction.Add("2", "以ReadAsync异步阻塞接收", () => { Console.WriteLine("2"); });

            consoleAction.ShowAll();
            consoleAction.RunCommandLine();
        }

        private static void RunClientForReceived()
        {
            Console.WriteLine("1");
        }
    }
}
