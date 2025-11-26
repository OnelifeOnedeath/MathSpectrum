namespace MathSpectrum.Core.Services;

public class FourierCalculator : IFourierCalculator
{
    public List<Harmonic> CalculateHarmonics(FunctionType functionType, int maxHarmonics, double period = 2 * Math.PI)
    {
        var harmonics = new List<Harmonic>();
        
        for (int n = 1; n <= maxHarmonics; n += 2) // Только нечётные гармоники
        {
            double amplitude = CalculateAmplitude(functionType, n, period);
            harmonics.Add(new Harmonic 
            { 
                Order = n, 
                Amplitude = amplitude,
                Frequency = n / period,
                Phase = 0
            });
        }
        
        return harmonics;
    }
    
    private double CalculateAmplitude(FunctionType functionType, int harmonicOrder, double period)
    {
        return functionType switch
        {
            FunctionType.SquareWave => (4 / (Math.PI * harmonicOrder)) * Math.Sin(harmonicOrder * Math.PI / 2),
            FunctionType.TriangleWave => (8 / (Math.PI * Math.PI * harmonicOrder * harmonicOrder)) * Math.Pow(-1, (harmonicOrder - 1) / 2),
            FunctionType.SawtoothWave => (2 / (Math.PI * harmonicOrder)) * Math.Pow(-1, harmonicOrder + 1),
            _ => 0
        };
    }
    
    public double CalculateFunctionValue(FunctionType functionType, double x, double period = 2 * Math.PI)
    {
        // Базовая функция без разложения в ряд
        double normalizedX = x % period;
        
        return functionType switch
        {
            FunctionType.SquareWave => normalizedX < period / 2 ? 1 : -1,
            FunctionType.TriangleWave => 2 * Math.Abs(2 * normalizedX / period - 1) - 1,
            FunctionType.SawtoothWave => 2 * (normalizedX / period) - 1,
            _ => 0
        };
    }
}
