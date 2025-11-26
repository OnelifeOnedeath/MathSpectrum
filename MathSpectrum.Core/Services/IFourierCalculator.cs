namespace MathSpectrum.Core.Services;

public interface IFourierCalculator
{
    List<Harmonic> CalculateHarmonics(FunctionType functionType, int maxHarmonics, double period = 2 * Math.PI);
    double CalculateFunctionValue(FunctionType functionType, double x, double period = 2 * Math.PI);
}
