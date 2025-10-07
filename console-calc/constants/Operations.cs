using System.Reflection;

public static class Operations
{
    public const string Plus = "+";
    public const string Minus = "-";
    public const string Multiply = "*";
    public const string Divide = "/";
    public static bool IsSupported(string entheredOperation)
    {
        var operations = typeof(Operations).GetFields(BindingFlags.Public | BindingFlags.Static).Where(field => field.IsLiteral && !field.IsInitOnly && field.FieldType == typeof(string));
        foreach (var operation in operations) 
        {
            if (operation.GetRawConstantValue()?.ToString() == entheredOperation)
                return true;
        }
        return false;
    }
}