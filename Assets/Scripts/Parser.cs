using System.Collections.Generic;
using System.Globalization;

public class Parser
{
    private string _numberOfOperation = "";

    public List<string> Parse(string data)
    {
        List<string> operation = new List<string>();

        foreach (var chr in data)
        {
            Add(chr, operation);
        }

        operation.Add(_numberOfOperation);

        Validate(operation);

        _numberOfOperation = "";

        return operation;
    }

    private void Add(char x, List<string> data)
    {
        if (char.IsDigit(x) || x == '.' || _numberOfOperation == "" && x == '-')
        {

            _numberOfOperation += x;
        }
        else
        {
            data.Add(_numberOfOperation);
            data.Add(x.ToString());
            _numberOfOperation = "";
        }
    }

    private void Validate(List<string> operation)
    {
        float number;
        var style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands;
        var culture = CultureInfo.CreateSpecificCulture("es-ES");

        if (float.TryParse(operation[operation.Count - 1], style, culture, out number))
        {
            return;
        }

        operation.RemoveAt(operation.Count - 1);
    }
}
