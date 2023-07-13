Pixel BackToFrontBlend(IEnumerable<Fragment> fragments)
{
    var dst = Pixel.OpaqueBlack;

    foreach (var f in fragments.OrderByDescending(f => f.Depth))
    {
        dst = new Pixel(
            f.Pixel.Alpha * f.Pixel.Color +
            (1.0 - f.Pixel.Alpha) * dst.Color,
            dst.Alpha * (1.0 - f.Pixel.Alpha));
    }

    return dst;
}

Pixel FrontToBackBlend(IEnumerable<Fragment> fragments)
{
    var dst = Pixel.OpaqueBlack;

    foreach (var f in fragments.OrderBy(f => f.Depth))
    {
        dst = new Pixel(
            dst.Color + f.Pixel.Alpha * dst.Alpha * f.Pixel.Color,
            dst.Alpha * (1.0 - f.Pixel.Alpha)
        );
    }

    return dst;
}

var rand = new Random(42);
var fragments = Enumerable.Range(0, 5)
    .Select(i => Fragment.Random(rand))
    .ToList();

Console.WriteLine("Behold the fragments:");
fragments.ForEach(f => Console.WriteLine(f));
Console.WriteLine("");

var backToFront = BackToFrontBlend(fragments);
var frontToBack = FrontToBackBlend(fragments);

if (backToFront.Color == frontToBack.Color)
{
    Console.WriteLine("Yeeehe!!! colors match!");
}
else
{
    Console.WriteLine("Boohohooo... colors don't match..");
    Console.WriteLine($"{backToFront.Color} vs {frontToBack.Color}");
}

if (backToFront.Alpha == frontToBack.Alpha)
{
    Console.WriteLine("Yeeehe!!! alpha match!");
}
else
{
    Console.WriteLine("Boohohooo... alphas don't match..");
    Console.WriteLine($"{backToFront.Alpha} vs {frontToBack.Alpha}");
}
