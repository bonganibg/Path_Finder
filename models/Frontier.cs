public class Frontier
{
    private List<Node> _frontier = new();
    private List<(Node node, int heuristic)> _fronterPriority = new();
    private FrontierType Type = FrontierType.Stack;

    public int Count { get => GetCount(); }

    private int GetCount()
    {
        return Type == FrontierType.PriorityQueue ? _fronterPriority.Count : _frontier.Count;
    }
    public Frontier(FrontierType type)
    {
        Type = type;
    }

    public void Add(Node node)
    {
        _frontier.Add(node);
    }
    
    public void Add(Node node, int heuristic)
    {
        _fronterPriority.Add((node, heuristic));
    }

    public bool Contains((int x, int y) state)
    {
        switch(Type)
        {
            case FrontierType.PriorityQueue: return ContainsPriotrity(state);
            default : return ContainsUninformed(state);
        }
    }

    private bool ContainsUninformed((int x, int y) state)
    {
        return  _frontier.Exists(item => item.State == state);
    }

    private bool ContainsPriotrity((int x, int y) state)
    {
        foreach(var node in _fronterPriority)
        {
            if (node.node.State == state)
                return true;
        }
        return false;
    }

    public Node Remove()
    {
        switch(Type)
        {
            case FrontierType.Stack: return RemoveStack();
            case FrontierType.Queue: return RemoveQueue();
            case FrontierType.PriorityQueue: return RemovePriorityQueue();
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

    private Node RemovePriorityQueue()
    {
        var item = _fronterPriority.MinBy(item => item.heuristic);
        _fronterPriority.Remove(item);
        return item.node;
    }
}