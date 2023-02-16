using System;

public class Money
{
    private int _hryvnia;
    private int _kopeck;

    public int Hryvnia
    {
        get { return _hryvnia; }
        set
        {
            if (value < 0)
                throw new BankruptException();
            _hryvnia = value;
        }
    }

    public int Kopeck
    {
        get { return _kopeck; }
        set
        {
            if (value < 0)
                throw new BankruptException();
            if (value >= 100)
            {
                _hryvnia += value / 100;
                value = value % 100;
            }
            _kopeck = value;
        }
    }

    public Money(int hryvnia, int kopeck)
    {
        Hryvnia = hryvnia;
        Kopeck = kopeck;
    }

    public static Money operator +(Money m1, Money m2)
    {
        int hryvnia = m1.Hryvnia + m2.Hryvnia;
        int kopeck = m1.Kopeck + m2.Kopeck;
        return new Money(hryvnia, kopeck);
    }

    public static Money operator -(Money m1, Money m2)
    {
        int hryvnia = m1.Hryvnia - m2.Hryvnia;
        int kopeck = m1.Kopeck - m2.Kopeck;
        return new Money(hryvnia, kopeck);
    }

    public static Money operator /(Money m, int n)
    {
        int hryvnia = m.Hryvnia / n;
        int kopeck = m.Kopeck / n;
        return new Money(hryvnia, kopeck);
    }

    public static Money operator *(Money m, int n)
    {
        int hryvnia = m.Hryvnia * n;
        int kopeck = m.Kopeck * n;
        return new Money(hryvnia, kopeck);
    }

    public static Money operator ++(Money m)
    {
        return new Money(m.Hryvnia, m.Kopeck + 1);
    }

    public static Money operator --(Money m)
    {
        return new Money(m.Hryvnia, m.Kopeck - 1);
    }

    public static bool operator <(Money m1, Money m2)
    {
        if (m1.Hryvnia < m2.Hryvnia)
            return true;
        else if (m1.Hryvnia == m2.Hryvnia && m1.Kopeck < m2.Kopeck)
            return true;
        else
            return false;
    }

    public static bool operator >(Money m1, Money m2)
    {
        if (m1.Hryvnia > m2.Hryvnia)
            return true;
        else if (m1.Hryvnia == m2.Hryvnia && m1.Kopeck > m2.Kopeck)
            return true;
        else
            return false;
    }

    public static bool operator ==(Money m1, Money m2)
    {
        return m1.Hryvnia == m2.Hryvnia && m1.Kopeck == m2.Kopeck;
    }

    public static bool operator !=(Money m1, Money m2)
    {
        return m1.Hryvnia != m2.Hryvnia || m1.Kopeck != m2.Kopeck;
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        Money m = (Money)obj;
        return Hryvnia == m.Hryvnia && Kopeck == m.Kopeck;
    }

    public override int GetHashCode()
    {
        return (Hryvnia << 16) + Kopeck;
    }

    public override string ToString()
    {
        return string.Format("{0} грн {1:00} коп", Hryvnia, Kopeck);
    }
}

public class BankruptException : Exception
{
    public BankruptException() : base("Банкрот") { }
}

public class Program
{
    public static void Main()
    {
        Money m1 = new Money(10, 50);
        Money m2 = new Money(5, 30);
        Console.WriteLine("m1 = {0}", m1);
        Console.WriteLine("m2 = {0}", m2);

        Money m3 = m1 + m2;
        Console.WriteLine("m1 + m2 = {0}", m3);

        Money m4 = m1 - m2;
        Console.WriteLine("m1 - m2 = {0}", m4);

        Money m5 = m1 / 2;
        Console.WriteLine("m1 / 2 = {0}", m5);

        Money m6 = m1 * 3;
        Console.WriteLine("m1 * 3 = {0}", m6);

        m1++;
        Console.WriteLine("m1++ = {0}", m1);

        m2--;
        Console.WriteLine("m2-- = {0}", m2);

        Console.WriteLine("m1 > m2 = {0}", m1 > m2);
        Console.WriteLine("m1 < m2 = {0}", m1 < m2);
        Console.WriteLine("m1 == m2 = {0}", m1 == m2);
        Console.WriteLine("m1 != m2 = {0}", m1 != m2);

        // Тестирование исключительной ситуации
        try
        {
            m2.Kopeck = -10;
        }
        catch (BankruptException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
