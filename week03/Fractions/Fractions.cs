using System;

public class Fraction
{
    private int _top;
    private int _bottom;

    // No-argument constructor
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    // Constructor with one argument (whole number)
    public Fraction(int wholeNumber)
    {
        _top = wholeNumber;
        _bottom = 1;
    }

    // Constructor with two arguments
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    // Getter for _top
    public int GetTop()
    {
        return _top;
    }

    // Setter for _top
    public void SetTop(int top)
    {
        _top = top;
    }

    // Getter for _bottom
    public int GetBottom()
    {
        return _bottom;
    }

    // Setter for _bottom
    public void SetBottom(int bottom)
    {
        _bottom = bottom;
    }

    // Return the fraction as a string like "3/4"
    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    // Return the decimal value of the fraction
    public double GetDecimalValue()
    {
        return (double)_top / _bottom;
    }
}
