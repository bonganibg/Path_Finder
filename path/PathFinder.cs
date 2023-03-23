
public class PathFinder
{

    private Map map = new Map("");
    public List<Direction> FindPath()
    {
        int total_paths_checked = 0;
        Node start_node = new Node((0,0));

        // Frontier and explored states
        Stack<Node> frontier = new Stack<Node>();
        HashSet<(int x, int y)> exploreredStates = new HashSet<(int x, int y)>();

        // Add start state to frontier
        frontier.Push(start_node);

        while(true)
        {
            // Check if there are items in the frontier
            if (frontier.Count <= 0)
                throw new System.Exception("There is no solution");

            // Set the node to check
            Node node = frontier.Pop();
            total_paths_checked++;

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
                if (frontier.ContainsState(dict_moves[direction]) || exploreredStates.Contains(dict_moves[direction]))
                    continue;
                else
                {
                    Node child = new Node(dict_moves[direction], node, direction);
                    frontier.Push(child);
                }
            }

        }

    }

    
}