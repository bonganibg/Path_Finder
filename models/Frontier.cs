public class Frontier
{
    private List<Node> _frontier = new();
    private FrontierType Type = FrontierType.Stack;

    public int Count { get => _frontier.Count; }

    public Frontier(FrontierType type)
    {
        Type = type;
    }

    public void Add(Node node)
    {
        _frontier.Add(node);
    }

    public bool Contains((int x, int y) state)
    {
        // var find_item = _frontier.Where(item => item.)
        return _frontier.Exists(item => item.State == state);
    }

    public Node Remove()
    {
        switch(Type)
        {
            case FrontierType.Stack: return RemoveStack();
            case FrontierType.Queue: return RemoveQueue();
        }
        throw new System.Exception("The Frontier does not exist");
    }

    private Node RemoveStack()
    {
        Node node = _frontier[_frontier.Count - 1];
        _frontier.RemoveAt(_frontier.Count - 1);
        return node;
    }

    private Node RemoveQueue()
    {
        Node node = _frontier[0];
        _frontier.RemoveAt(0);
        return node;   
    }
}