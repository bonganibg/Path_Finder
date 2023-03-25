using path_finder.views;
public class InformedSearch
{
    private (int x, int y) goal_position = (2, 11);
    private Map map = new Map("");


    public List<Direction> FindPath()
    {
        int total_paths_checked = 0;
        Node start_node = new Node((9, 0));
        

        HashSet<(int x, int y)> explored = new();
        Frontier frontier = new Frontier(FrontierType.PriorityQueue);

        frontier.Add(start_node, CheckDistance(start_node.State, goal_position));
        
        Visual visual = new Visual();

        while(true)
        {
            if (frontier.Count <= 0)
                throw new System.Exception("The journey ends here");

            // Setup the node that needs to be checked
            Node node = frontier.Remove();            
            total_paths_checked++;

            visual.ShowMap(map.GetMap(), node.State, explored.ToList());
            Console.ReadKey();

            // Check if node is the goal node 
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

            // Update the frontier and explored states
            explored.Add(node.State);

            var dict_moves = map.GetMoveAndPosition(node.State);
            foreach(var direction in dict_moves.Keys)
            {
                if (frontier.Contains(dict_moves[direction]) || explored.Contains(dict_moves[direction]))
                    continue;
                else
                {
                    Node child = new Node(dict_moves[direction], node, direction);
                    frontier.Add(child, CheckDistance(child.State, goal_position));
                }
            }
        }
    }

    public int CheckDistance((int x, int y) state, (int x, int y) goal_coord)
    {
        int x = Math.Abs(state.x - goal_coord.x);
        int y = Math.Abs(state.y - goal_coord.y);

        return x + y;
    }

}