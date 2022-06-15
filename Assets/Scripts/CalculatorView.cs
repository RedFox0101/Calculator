using UnityEngine;
using TMPro;

public class CalculatorView : MonoBehaviour
{
    [SerializeField] private TMP_Text _resultatLabel;
    [SerializeField] private TMP_Text _prematureResultLabel;
    [SerializeField] private AnimatorLabels _animatorLabels;

    private Calculator _calculator;
    private Parser _parser;
    private char _lastDialedCharacter = '0';

    private void Awake()
    {
        _calculator = new Calculator();
        _parser = new Parser();
        _resultatLabel.text = "";
    }

    private string GetResultat(string text)
    {
        var data = _parser.Parse(text);
        var resultat = _calculator.CalculateRelult(data);
        _lastDialedCharacter = '0';
        resultat = resultat.Replace(",", ".");
        return resultat;
    }

    public void GetResultat()
    {
        if (_prematureResultLabel.text.Contains("Ошибка"))
        {
            return;
        }

        _resultatLabel.text = GetResultat(_resultatLabel.text);
        _animatorLabels.enabled = true;
    }

    public void Delete()
    {
        if (_resultatLabel.text.Length == 0)
        {
            return;
        }

        _resultatLabel.text = _resultatLabel.text.Substring(0, _resultatLabel.text.Length - 1);
        _lastDialedCharacter = '0';
    }

    public void Add(char chr)
    {
        if (!char.IsDigit(chr) && !char.IsDigit(_lastDialedCharacter))
            return;
        if (_resultatLabel.text.Length == 0 && chr == '+')
            return;

        _resultatLabel.text += chr;
        _lastDialedCharacter = chr;

        if (char.IsDigit(chr))
        {
            _prematureResultLabel.text = GetResultat(_resultatLabel.text);
        }
    }
}
