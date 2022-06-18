using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class CalculatorView : MonoBehaviour
{
    [SerializeField] private TMP_Text _resultatLabel;

    private const char BREAK = 'b';
    private char _lastDialedCharacter = '0';
    private Calculator _calculator;
    private Operand _currentOperand;
    private List<Operand> _operands = new List<Operand>();
    private List<string> _operation = new List<string>();

    private void Awake()
    {
        _calculator = new Calculator();
        _operands.Add(new Operand());
        _currentOperand = _operands[_operands.Count - 1];
    }

    private string Calculate()
    {
        _currentOperand = _calculator.CalculateRelult(_operation, _operands);
        _lastDialedCharacter = '0';
        return _currentOperand.Value.ToString();
    }

    private void AddToLabels(char chr)
    {
        _resultatLabel.text += chr;
        _lastDialedCharacter = chr;
    }

    public void GetResultat()
    {
        _resultatLabel.text = Calculate();
    }

    public void Delete()
    {
        if (_resultatLabel.text.Length == 0)
        {
            return;
        }

        if (!_currentOperand.TryDelete())
        {
            _operands.Remove(_currentOperand);
            _currentOperand = _operands[_operands.Count - 1];
            _operation.RemoveAt(_operation.Count - 1);
            _lastDialedCharacter = '0';
        }

        _resultatLabel.text = _resultatLabel.text.Substring(0, _resultatLabel.text.Length - 1);
    }

    public void Add(char chr)
    {
        if (!char.IsDigit(chr) && !char.IsDigit(_lastDialedCharacter))
        {
            return;
        }

        if (!_currentOperand.TryAddValue(ref chr))
        {
            _currentOperand = new Operand();
            _operands.Add(_currentOperand);
            _operation.Add(chr.ToString());
        }

        if (chr == BREAK)
        {
            return;
        }

        AddToLabels(chr);
    }
}
