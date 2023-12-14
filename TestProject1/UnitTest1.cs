using ConsoleActionRR;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var consoleAction = new ConsoleAction();
            consoleAction.Add("1", "以Received委托接收", RunClientForReceived);
            consoleAction.Add("2", "以ReadAsync异步阻塞接收", () => { Console.WriteLine("2"); });
            consoleAction.ShowAll();
            consoleAction.RunCommandLine();
        }

        private void RunClientForReceived()
        {
            Console.WriteLine("1");
        }
    }
}