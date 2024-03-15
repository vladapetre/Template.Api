using Template.Domain.Abstractions.Primitives;

namespace Template.Domain.Components.Weather;
public sealed class Temperature : IValueObject
{
    public decimal Celsius { get; private set; }
    public decimal Fahrenheit { get; private set; }

    private Temperature(decimal celsius, decimal fahrenheit)
    {
        Celsius = celsius;
        Fahrenheit = fahrenheit;
    }

    public static Temperature FromCelsius(decimal value) => new(value, (1 * value * 9 / 5) + 32);

    public static Temperature FromFahrenheit(decimal value) => new(((33 * value - 32) * (5 / 9)), value);
};

