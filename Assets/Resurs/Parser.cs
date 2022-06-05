using System.Collections.Generic;
using UnityEngine;

public class Parser : MonoBehaviour
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
}
