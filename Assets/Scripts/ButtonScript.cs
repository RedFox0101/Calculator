using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Button))]
public class ButtonScript : MonoBehaviour
{
    [SerializeField] private char _numer;
    [SerializeField] CalculatorView _calculator;

    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(SetData);
    }

    private void SetData()
    {
        _calculator.Add(_numer);
    }
}
