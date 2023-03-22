public static class Exception
{
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
}