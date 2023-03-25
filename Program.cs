InformedSearch finder = new InformedSearch();

var path = finder.FindPath();

foreach(var location in path)
{
    Console.WriteLine(location.ToString());
}

