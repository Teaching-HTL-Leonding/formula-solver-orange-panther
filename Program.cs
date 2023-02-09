//credits: ChatGPT, thanks for the code
int result = 0;

Console.WriteLine("Enter a formula: ");
string formula = Console.ReadLine()!;
formula = formula.Replace(" ", string.Empty);

if (formula == string.Empty)
{
    result = 0;
}
else if (IsNumeric(formula))
{
    result = int.Parse(formula);
}
else
{
    result = EvaluateFormula(formula);
}

Console.WriteLine($"Your result: {result}");

bool IsNumeric(string formula)
{
    int value;
    return int.TryParse(formula, out value);
}

int EvaluateFormula(string formula)
{
    int result = 0;
    int currentValue = 0;
    char currentOperator = '+';
    for (int i = 0; i < formula.Length; i++)
    {
        char c = formula[i];
        if (char.IsDigit(c))
        {
            currentValue = currentValue * 10 + (c - '0');
        }
        else
        {
            switch (currentOperator)
            {
                case '+':
                    result += currentValue;
                    break;
                case '-':
                    result -= currentValue;
                    break;
            }
            currentValue = 0;
            currentOperator = c;
        }
    }
    switch (currentOperator)
    {
        case '+':
            result += currentValue;
            break;
        case '-':
            result -= currentValue;
            break;
    }
    return result;
}
