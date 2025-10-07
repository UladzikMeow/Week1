while (true) {
    try
    {
        double firstNumber = ConsoleCalculator.ReadNumber("Введите первое число");
        string operation = ConsoleCalculator.ReadOperation();
        double secondNumber = ConsoleCalculator.ReadNumber("Введите второе число");
        Console.WriteLine($"{firstNumber} {operation} {secondNumber} = {ConsoleCalculator.Calculate(firstNumber, secondNumber, operation)}");
        if (!ShallContinue())
            break;
    }
    catch (Exception e) 
    { 
        Console.WriteLine(e.Message);
        if (!ShallContinue())
            break;
    }
}

bool ShallContinue()
{
    while (true)
    {
        Console.WriteLine("Желаете продолжить?(y/n)");
        string? ans = Console.ReadLine();
        if (ans == "n")
            return false;
        else if (ans == "y")
            return true;
        Console.WriteLine($"Вы ввеоли {ans}.Введите y/n");
    }
}
