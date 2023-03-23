public static class Exception
{

    // Get the values to traverse the map based on direction
    public static (int x, int y) GetValue(this Direction direction)
    {
        switch(direction)
        {
            case Direction.Up : return (0, -1);
            case Direction.Down : return(0, 1);
            case Direction.Left : return (-1, 0);
            case Direction.Right : return (1, 0);
        }
        
        throw new System.Exception("Directon does to exist");
    }

    // Check Stack contains state
    public static bool ContainsState(this Stack<Node> stack, (int x, int y) state)
    {
        for(int i = 0; i < stack.Count; i++)
        {
            if (stack.ElementAt(i).State == state)
                return true;
        }
        return false;
    }
}