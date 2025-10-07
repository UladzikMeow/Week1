public static class ConsoleCalculator
{
    public static double Calculate(double x, double y, string operation)
    {
        switch (operation) 
        {
            case Operations.Plus: return x + y;
            case Operations.Minus: return x - y;
            case Operations.Divide: return y == 0 ? throw new Exception($"Попытка деления на ноль") : x / y;
            case Operations.Multiply: return x * y;
            default: throw new Exception($"Операция {operation} не обрабатывается");
        }
    }
    
    public static double ReadNumber()
    {
        return ReadNumber("Введите число");
    }
    public static double ReadNumber(string prompt)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            if(double.TryParse(Console.ReadLine()?.Replace(".", ","), out double number))
                return number;
            Console.WriteLine("Вы ввели не число.");
        }
    }
    public static string ReadOperation()
    {
        return ReadOperation("Введите операцию");
    }
    public static string ReadOperation(string prompt)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            string? op = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(op))
            {
                Console.WriteLine("Вы не ввели операцию.");
                continue;
            }
            if (!Operations.IsSupported(op))
            {
                Console.WriteLine("Операция не поддерживается.");
                continue;
            }
            return op;
        }
    }
}
