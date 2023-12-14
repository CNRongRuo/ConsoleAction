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
            consoleAction.Add("1", "��Receivedί�н���", RunClientForReceived);
            consoleAction.Add("2", "��ReadAsync�첽��������", () => { Console.WriteLine("2"); });
            consoleAction.ShowAll();
            consoleAction.RunCommandLine();
        }

        private void RunClientForReceived()
        {
            Console.WriteLine("1");
        }
    }
}