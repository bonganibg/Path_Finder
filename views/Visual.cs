using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace path_finder.views
{
    public class Visual
    {
        private List<(int x, int y)> _explored;
        private (int x, int y) _current;
        public Visual()
        {

        }   

        public void ShowMap(string[][] map, (int x, int y) current, List<(int x, int y)> explored)
        {
            _explored = explored;
            _current = current;

            Console.Clear();

            for (int i = 0; i < map.Length; i++)
            {
                for (int k = 0; k < map[i].Length; k++)
                {
                    GetCellColor(map[i][k]);
                    GetColors((i, k));

                    Console.Write($"{map[i][k]} ");
                }
                Console.WriteLine();
            }
        }
        
        private void GetColors((int x, int y) position)
        {
            if (_explored.Contains(position))
                Console.ForegroundColor = ConsoleColor.Green;
            else if (position == _current)
                Console.ForegroundColor = ConsoleColor.Yellow;
        }

        private void GetCellColor(string value)
        {
            if (value == "-")
                Console.ForegroundColor = ConsoleColor.White;
            else if (value == "+")
                Console.ForegroundColor = ConsoleColor.Red;
        }
    }
}
