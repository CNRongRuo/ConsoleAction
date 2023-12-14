namespace ConsoleActionRR
{
    internal struct CAction
    {
        public Action Action { get; }
        public string Descripyion { get; }
        public string FullOrder { get; }
        public CAction(string description, string fullOrder, Action action)
        {
            this.Descripyion = description ?? throw new ArgumentNullException(nameof(description));
            this.Action = action ?? throw new ArgumentNullException(nameof(action));
            this.FullOrder = fullOrder ?? throw new ArgumentNullException(nameof(fullOrder));
        }
    }
    public class ConsoleAction
    {

        public string HelpOrder { get; private set; }

        public event Action<Exception> OnException;
        private readonly Dictionary<string, CAction> actions = new Dictionary<string, CAction>();
        public ConsoleAction(string helpOrder = "h|help|?", string title = $"")
        {
            this.HelpOrder = helpOrder;
            this.Add(helpOrder, "帮助信息", this.ShowAll);
            if (string.IsNullOrEmpty(title))
            {
                Console.WriteLine(title);
            }


        }
        public void Add(string order, string description, Action action)
        {
            var orders = order.ToLower().Split('|');
            foreach (var o in orders)
            {
                this.actions.Add(o, new CAction(description, order, action));
            }
        }

        public void RunCommandLine()
        {
            while (true)
            {
                var str = Console.ReadLine();
                if (!this.Run(str))
                {
                    Console.WriteLine($"没有这个指令");
                }
            }
        }

        public bool Run(string order)
        {
            if (this.actions.TryGetValue(order, out CAction action))
            {
                try
                {
                    action.Action.Invoke();

                }
                catch (Exception ex)
                {
                    OnException?.Invoke(ex);

                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ShowAll()
        {
            var max = this.actions.Values.Max(a => a.FullOrder.Length) + 8;
            var s = new List<string>();
            foreach (var item in this.actions)
            {
                if (!s.Contains(item.Value.FullOrder.ToLower()))
                {
                    s.Add(item.Value.FullOrder.ToLower());
                    Console.Write($"[{item.Value.FullOrder}]");
                    for (int i = 0; i < max - item.Value.FullOrder.Length; i++)
                    {
                        Console.Write("-");
                    }
                    Console.WriteLine(item.Value.Descripyion);
                }

            }
        }

    }
}
