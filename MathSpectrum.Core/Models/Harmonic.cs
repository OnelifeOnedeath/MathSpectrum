namespace MathSpectrum.Core.Models;

public class Harmonic
{
    public int Order { get; set; }           // Порядок гармоники (1, 3, 5...)
    public double Amplitude { get; set; }    // Амплитуда
    public double Frequency { get; set; }    // Частота
    public double Phase { get; set; }        // Фаза
}
