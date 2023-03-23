PathFinder finder = new PathFinder();

var path = finder.FindPath();

foreach(var location in path)
{
    Console.WriteLine(location.ToString());
}

