public class Fragment
{
    public Fragment(Pixel pixel, double depth)
    {
        Pixel = pixel;
        Depth = depth;
    }

    public static Fragment Random(Random random) =>
        new Fragment(Pixel.Random(random), random.NextDouble());

    public Pixel Pixel { get; }

    public double Depth { get; }

    public override String ToString() => $"Fragment(pixel: {Pixel}, depth: {Depth:0.000})";
}
