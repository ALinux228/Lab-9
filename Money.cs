internal class Money
{
    private uint _rubles;
    private byte _kopeks;

    public Money(string rubles, string kopeks)
    {
        if (int.TryParse(rubles, out int rublesValue) &&
            int.TryParse(kopeks, out int kopeksValue))
        {
            if ((rublesValue < 0) || (kopeksValue < 0)) 
            { 
                Console.WriteLine("Введите неотрицательные числа");
                _rubles = 0;
                _kopeks = 0;
            }
            else
            {
                if (kopeksValue > 100)
                {
                    _kopeks = (byte)(kopeksValue % 100);
                    _rubles = (uint)(rublesValue + kopeksValue / 100);
                }
                else
                {
                    _rubles = (uint)rublesValue;
                    _kopeks = (byte)kopeksValue;
                }   
            }
        }
        else
        {
            Console.WriteLine("Введите корректные числа");
            _rubles = 0;
            _kopeks = 0;
        }
    }

    public Money(uint rubles, byte kopeks)
    {
        _rubles = rubles;
        _kopeks = kopeks;
    }   

    public Money(int totalKopeks)
    {
        if (totalKopeks < 0)
        {
            totalKopeks = 0;
        }
        _rubles = (uint)(totalKopeks / 100);
        _kopeks = (byte)(totalKopeks % 100);
    }

    public static Money operator ++(Money m)
    {
        Money result = new Money(m._rubles, m._kopeks);
        result = result.Add(1);
        return result;
    }

    public static Money operator --(Money m)
    {
        Money result = new Money(m._rubles, m._kopeks);
        result = result.Subtract(1);
        return result;
    }

    public static explicit operator uint(Money m)
    {
        return m._rubles;
    }

    public static implicit operator double(Money m)
    {
        return m._kopeks / 100.0;
    }

    public static Money operator +(Money m, uint rub)
    {
        return new Money(m._rubles + rub, m._kopeks);
    }

    public static Money operator -(Money m, uint rub)
    {
        if (m._rubles < rub)
        {
            Console.WriteLine("Недостаточно рублей для вычитания");
            return new Money(m._rubles, m._kopeks);
        }
        else
        {
            return new Money(m._rubles - rub, m._kopeks);
        }
    }

    public Money Add(int kop)
    {
        int total = (int)(_rubles * 100 + _kopeks + kop);
        if (total < 0)
        {
            total = 0;
        }
        return new Money(total);
    }

    public Money Subtract(int kop)
    {
        int total = (int)(_rubles * 100 + _kopeks - kop);
        if (total < 0)
        {
            total = 0;
        }
        return new Money(total);
    }

    public override string ToString()
    {
        return $"{_rubles} руб. {_kopeks:D2} коп.";
    }
}
