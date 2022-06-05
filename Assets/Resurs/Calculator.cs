using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Globalization;


public class Calculator : MonoBehaviour
{
    public UnityAction<string> Resultat;

    public void CalculateRelult(List<string> data)
    {
        while (data.Count > 2)
        {
            for (int i = 0; i < data.Count; i++)
            {
                float sum;

                if (data[i].Contains("*"))
                {
                    sum = float.Parse(data[i - 1], CultureInfo.InvariantCulture.NumberFormat) * float.Parse(data[i + 1], CultureInfo.InvariantCulture.NumberFormat);
                    DeleteDeletingÑalculations(data, i, sum);

                }
                else if (data[i].Contains("/"))
                {
                    sum = float.Parse(data[i - 1], CultureInfo.InvariantCulture.NumberFormat) / float.Parse(data[i + 1], CultureInfo.InvariantCulture.NumberFormat);
                    DeleteDeletingÑalculations(data, i, sum);
                }


            }

            for (int i = 0; i < data.Count; i++)
            {
                float resultat = 0;

                if (data[i].Contains("+"))
                {
                    resultat = float.Parse(data[i - 1], CultureInfo.InvariantCulture.NumberFormat) + float.Parse(data[i + 1], CultureInfo.InvariantCulture.NumberFormat);
                    DeleteDeletingÑalculations(data, i, resultat);
                }

                else if (data[i].Contains("-"))
                {
                    if (data[i].Length == 1)
                    {
                        resultat = float.Parse(data[i - 1], CultureInfo.InvariantCulture.NumberFormat) - float.Parse(data[i + 1], CultureInfo.InvariantCulture.NumberFormat);
                        DeleteDeletingÑalculations(data, i, resultat);
                    }
                }

            }
        }

        Resultat?.Invoke(data[0]);
        data.RemoveAt(0);
    }

    private static void DeleteDeletingÑalculations(List<string> data, int indexOfList, float sum)
    {
        data.RemoveAt(indexOfList + 1);
        data.RemoveAt(indexOfList);
        data[indexOfList - 1] = sum.ToString();
    }
}
