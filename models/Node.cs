public class Node{
    public (int x, int y) State { get; set; }
    public Node Parent { get; set; } = null;
    public Direction Action { get; set; }

    public Node((int x, int y) State)
    {
        this.State = State;
    }
    
    public Node((int x, int y) state, Node parent, Direction action)
    {
        State = state;
        Parent = parent;
        Action = action;
    }
}