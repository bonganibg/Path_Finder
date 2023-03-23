public class Map
{
    private string[][] _map;
    private string _location = @"..\..\..\files\map1.txt";

    public Map(string location)
    {
        LoadMap(_location);
    }

    private void LoadMap(string location)
    {
        string[] lines = File.ReadAllLines(location);
        _map = new string[lines.Length][];

        for(int i = 0; i < lines.Length; i++)
        {
            string[] cells = lines[i].Split(' ');
            _map[i] = cells;
        }
    }

    public string[][] GetMap()
    {
        return _map;
    }

    public string GetValue((int x, int y) pos)
    {
        return _map[pos.x][pos.y];
    }

    public (int x, int y) GetBounds()
    {
        (int x, int y) positoins = (_map.Length, _map[0].Length);
        return positoins;
    }

    public Dictionary<Direction, (int x, int y)> GetMoveAndPosition((int x, int y) current)
    {
        Dictionary<Direction, (int x, int y)> output = new();

        foreach(var direction in GetAvailableMoves(current))
        {
            output.Add(direction, (current.x + direction.GetValue().x, current.y + direction.GetValue().y));
        }

        return output;
    }

    // Returns moves than can be made excluding walls
    // Returns an enum of the direction
    // REPLACE WITH GetMoveAndPositoin
    public List<Direction> GetAvailableMoves((int x, int y) currentPosition)
    {
        List<Direction> availableDirections = new();

        if (isMoveAvailable(currentPosition, Direction.Up))
            availableDirections.Add(Direction.Up);
        
        if (isMoveAvailable(currentPosition, Direction.Down))
            availableDirections.Add(Direction.Down);
        
        if (isMoveAvailable(currentPosition, Direction.Left))
            availableDirections.Add(Direction.Left);
        
        if (isMoveAvailable(currentPosition, Direction.Right))
            availableDirections.Add(Direction.Right);

        return availableDirections;
    }
    
    // Check if a move is available
    private bool isMoveAvailable((int x, int y) c_pos, Direction move)
    {
        (int x, int y) d_pos = move.GetValue();
        (int x, int y) position = (c_pos.x + d_pos.x, c_pos.y + d_pos.y);

        // Check position
        if(position.x < 0 || position.y < 0)
            return false;
        else if (position.x >= GetBounds().x || position.y >= GetBounds().y)
            return false;

        // Check value
        if (_map[position.x][position.y] == "-")
            return false;
        
        return true;
    }
}