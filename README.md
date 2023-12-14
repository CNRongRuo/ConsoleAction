控制台指令
``` csharp
            var consoleAction = new ConsoleAction();
            consoleAction.Add("1", "以Received委托接收", RunClientForReceived);
            consoleAction.Add("2", "以ReadAsync异步阻塞接收", () => { Console.WriteLine("2"); });

            consoleAction.ShowAll();
            consoleAction.RunCommandLine();
```


![image](https://github.com/CNRongRuo/ConsoleAction/assets/77100246/22dbcc2e-3297-4df3-9164-a9dec52168eb)
