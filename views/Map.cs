public class Map
{
    private string[][] _map;
    private string _location = @"C:\Users\user\Documents\Development Stuff\AI\CS50_AI_0_Search\practice\path_finder\files\map1.txt";

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

    public (int x, int y) GetBounds()
    {
        if (_map is null)
            throw new Exception("There is nothing there");
        else 
        {
            (int x, int y) positoins = (_map.Length, _map[0].Length);
            return positoins;
        }
    }

    // Returns moves than can be made excluding walls
    // Returns an enum of the direction
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
        if (_map[position.x][position.y] == "+")
            return false;
        
        return true;
    }
}