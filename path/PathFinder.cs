
using path_finder.views;

public class PathFinder
{

    private Map map = new Map("");
    public List<Direction> FindPath()
    {
        int total_paths_checked = 0;
        Node start_node = new Node((9,0));

        // Frontier and explored states
        Frontier frontier = new Frontier(FrontierType.Queue);
        // Stack<Node> frontier = new Stack<Node>();
        // Queue<Node> frontier = new Queue<Node>();
        HashSet<(int x, int y)> exploreredStates = new HashSet<(int x, int y)>();

        // Add start state to frontier
        // frontier.Push(start_node);
        frontier.Add(start_node);

        Visual visual = new Visual();        

        while(true)
        {           
            // Check if there are items in the frontier
            if (frontier.Count <= 0)
                throw new System.Exception("There is no solution");

            // Set the node to check
            // Node node = frontier.Pop();
            Node node = frontier.Remove();
            total_paths_checked++;

            visual.ShowMap(map.GetMap(), node.State, exploreredStates.ToList());
            Console.ReadKey();

            // Check if node is goal
            if (map.GetValue(node.State) == "2")
            {
                List<Direction> path = new();
                while(node.Parent is not null)
                {
                    path.Add(node.Action);
                    node = node.Parent;
                }                
                return path;
            }

            // Add node to explored
            exploreredStates.Add(node.State);

            var dict_moves = map.GetMoveAndPosition(node.State);
            // Get next node 
            foreach(var direction in dict_moves.Keys)
            {
                if (frontier.Contains(dict_moves[direction]) || exploreredStates.Contains(dict_moves[direction]))
                    continue;
                else
                {
                    Node child = new Node(dict_moves[direction], node, direction);
                    frontier.Add(child);
                }
            }

        }

    }

    
 }