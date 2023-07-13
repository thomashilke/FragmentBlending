public class Pixel
{
    public Pixel(double color, double alpha)
    {
        Color = color;
        Alpha = alpha;
    }

    public static Pixel Random(Random random) =>
        new Pixel(random.NextDouble(), random.NextDouble());

    public static readonly Pixel OpaqueBlack = new Pixel(0.0, 1.0);

    public static readonly Pixel TransparentBlack = new Pixel(0.0, 0.0);

    public double Color { get; }

    public double Alpha { get; }

    public override String ToString() => $"Pixel(color: {Color:0.000}, alpha: {Alpha:0.000})";
}
