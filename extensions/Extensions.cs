public static class Exception
{

    // Get the values to traverse the map based on direction
    public static (int x, int y) GetValue(this Direction direction)
    {
        switch(direction)
        {
            case Direction.Up : return (-1, 0);
            case Direction.Down : return(1, 0);
            case Direction.Left : return (0, -1);
            case Direction.Right : return (0, 1);
        }
        
        throw new System.Exception("Directon does to exist");
    }
}