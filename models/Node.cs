public class Node{
    public String State { get; set; }
    public Node Parent { get; set; } = null;
    public String Action { get; set; } = null;

    public Node(String State)
    {
        this.State = State;
    }
    
    public Node(String state, Node parent, String action)
    {
        State = state;
        Parent = parent;
        Action = action;
    }
}