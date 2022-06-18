using System.Globalization;

[System.Serializable]
public class Operand
{
    public float Value { get; private set; }

    private string _buff = "";
    private const char BREAK = 'b';

    private void TryParse(string data)
    {
        if (_buff.Length == 0)
        {
            Value = 0;
            return;
        }
        if (float.TryParse(data, out float resultat))
        {
            Value = resultat;
        }
    }

    private bool Point—heck(ref char chr)
    {
        if (chr == '.')
        {
            if (!_buff.Contains("."))
            {
                _buff += chr;
            }
            else
            {
                chr = BREAK;
            }
            return true;
        }
        return false;
    }

    public bool TryAddValue(ref char chr)
    {
        if (float.TryParse(chr.ToString(), out float resultat))
        {
            _buff += chr;  
            Value = float.Parse(_buff, CultureInfo.InvariantCulture.NumberFormat);
            return true;
        }

        return Point—heck(ref chr);    
    }

    public void SetValue(float value)
    {
        if(value== float.PositiveInfinity|| value == float.NegativeInfinity)
        {
            value = 0;
        }

        Value = value;
        
        _buff = value.ToString();
       
        _buff = _buff.Replace(",", ".");
    }

    public bool TryDelete()
    {

        if (_buff.Length != 0)
        {
            _buff = _buff.Substring(0, _buff.Length - 1);
            TryParse(_buff);
            return true;
        }
        return false;
    }
}