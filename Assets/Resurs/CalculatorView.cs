using UnityEngine;
using TMPro;

[RequireComponent(typeof(Parser))]
public class CalculatorView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Calculator _calculator;

    private char _lastDialedCharacter='0';

    private Parser _parser;

    private void Start()
    {
        _parser = GetComponent<Parser>();
        _text.text = "";
    }

    private void OnEnable()
    {
        _calculator.Resultat += Show;
    }

    private void OnDisable()
    {
        _calculator.Resultat -= Show;
    }

    private void Show(string str)
    {
        str = str.Replace(",", ".");
        _text.text = str;
    }

    public void GetResultat()
    {
        _calculator.CalculateRelult(_parser.Parse(_text.text));
    }

    public void Delete()
    {
        _lastDialedCharacter = _text.text[_text.text.Length - 1];
        _text.text = _text.text.Substring(0, _text.text.Length - 1);
    }

    public void Add(char chr)
    {
        if (!char.IsDigit(chr) && !char.IsDigit(_lastDialedCharacter))
            return;

        _text.text += chr;
        _lastDialedCharacter = chr;
    }
}
