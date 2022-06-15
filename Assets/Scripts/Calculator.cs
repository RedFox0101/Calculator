using System.Collections.Generic;
using System.Globalization;

public class Calculator
{
    private delegate float Operation(float x, float y);

    public string CalculateRelult(List<string> data)
    {
        while (data.Count > 2)
        {
            float resultat = 0;
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i].Contains("*"))
                {
                    resultat = CalculateResult(data, i, (x, y) => x * y);
                    DeleteDeletingÑalculations(data, i, resultat);
                }
                else if (data[i].Contains("/"))
                {
                    if (data[i + 1] == "0")
                    {
                        return "Îøèáêà";
                    }

                    resultat = CalculateResult(data, i, (x, y) => x / y);
                    DeleteDeletingÑalculations(data, i, resultat);
                }
            }
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i].Contains("+"))
                {
                    resultat = CalculateResult(data, i, (x, y) => x + y);
                    DeleteDeletingÑalculations(data, i, resultat);
                }
                else if (data[i].Contains("-"))
                {
                    if (data[i].Length == 1)
                    {
                        resultat = CalculateResult(data, i, (x, y) => x - y);
                        DeleteDeletingÑalculations(data, i, resultat);
                    }
                }
            }
        }
        return data[0];
    }

    private float CalculateResult(List<string> data, int indexOfList, Operation operat)
    {
        float operand_1 = ConverToFloat(data[indexOfList - 1]);
        float operand_2 = ConverToFloat(data[indexOfList + 1]);
        return  operat.Invoke(operand_1, operand_2);    
    }

    private static void DeleteDeletingÑalculations(List<string> data, int indexOfList, float resultat)
    {
        data.RemoveAt(indexOfList + 1);
        data.RemoveAt(indexOfList);
        data[indexOfList - 1] = resultat.ToString();
    }

    private float ConverToFloat(string operand)
    {
        return float.Parse(operand, CultureInfo.InvariantCulture.NumberFormat);
    }
}
