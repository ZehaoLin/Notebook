class BreadthFirstSearch
{
    private bool[] marked;
    private int[] edgeTo;
    private int sourceVetical;//Source vertical

    public BreadthFirstSearch(Graph g, int s)
    {
        marked=new bool[g.GetVerticals()];
        edgeTo=new int[g.GetVerticals()];
        this.sourceVetical = s;
        bfs(g, s);
    }

    private void bfs(Graph g, int s)
    {
        Queue<int> queue = new Queue<int>();
        marked[s] = true;
        queue.Enqueue(s);
        while (queue.Count()!=0)
        {
            int v = queue.Dequeue();
            foreach (int w in g.GetAdjacency(v))
            {
                if (!marked[w])
                {
                    edgeTo[w] = v;
                    marked[w] = true;
                    queue.Enqueue(w);
                }
            }
        }
    }

    public bool HasPathTo(int v)
    {
        return marked[v];
    }

    public Stack<int> PathTo(int v)
    {
        if (!HasPathTo(v)) return null;

        Stack<int> path = new Stack<int>();
        for (int x = v; x!=sourceVetical; x=edgeTo[x])
        {
            path.Push(x);
        }
        path.Push(sourceVetical);
        return path;
    }
}