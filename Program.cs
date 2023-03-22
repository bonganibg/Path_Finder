Map map = new Map("");

var availableDirections = map.GetAvailableMoves((0,0));

foreach(var item in availableDirections)
{
    Console.WriteLine(item);
}