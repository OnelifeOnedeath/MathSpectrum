using MathSpectrum.Core.Models;
using MathSpectrum.Core.Services;
using Xunit;

namespace MathSpectrum.Core.Tests;

public class FourierCalculatorTests
{
    [Theory]
    [InlineData(FunctionType.SquareWave, 1, 4/Math.PI)]
    [InlineData(FunctionType.SquareWave, 3, 4/(3*Math.PI))]
    public void CalculateHarmonics_ReturnsCorrectAmplitudes(FunctionType type, int order, double expectedAmplitude)
    {
        var calculator = new FourierCalculator();
        var harmonics = calculator.CalculateHarmonics(type, order);
        
        Assert.Equal(expectedAmplitude, harmonics.Last().Amplitude, 0.001);
    }
}
