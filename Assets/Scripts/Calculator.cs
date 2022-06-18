using System.Collections.Generic;

public class Calculator
{
    public Operand CalculateRelult( List<string> operation,  List<Operand> operands)
    {
        while (operation.Count > 0)
        {
            float resultat = 0;

            for (int i = 0; i < operation.Count; i++)
            {
                if (operation[i].Contains("*"))
                {
                    resultat = operands[i].Value * operands[i + 1].Value;
                    DeleteData(operation, operands, resultat, i);
                }
                else if (operation[i].Contains("/"))
                {
                    resultat = operands[i].Value / operands[i + 1].Value;
                    DeleteData(operation, operands, resultat, i);
                }
            }

            for (int i = 0; i < operation.Count; i++)
            {
                if (operation[i].Contains("+"))
                {
                    resultat = operands[i].Value + operands[i + 1].Value;
                    DeleteData(operation, operands, resultat, i);
                }
                else if (operation[i].Contains("-"))
                {
                    resultat = operands[i].Value - operands[i + 1].Value;
                    DeleteData(operation, operands, resultat, i);
                }
            }
        }

        return operands[0];
    }

    private static void DeleteData(List<string> operation, List<Operand> operands, float resultat, int i)
    {
        operands.RemoveAt(i + 1);
        operands[i].SetValue(resultat);
        operation.RemoveAt(i);
    }
}
