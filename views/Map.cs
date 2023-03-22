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

    private string[][] GetMap()
    {
        return _map;
    }
}