//深度优先搜索

public class DepthFirstSearch {
    private bool[] marked;//记录顶点是否被标记
    private int count;//记录查找的次数

    private DepthFirstSearch(Graph g, int v)
    {
        marked = new bool[g.GetVerticals];
        dfs(g, v);
    }

    private void dfs(Graph g, int v)
    {
        marked[v] = true;
        count++;
        foreach (var item in g.GetAdjacency(v))
        {
            if (marked[vertical] == false)
                dfs(g, vertical);
        }
    }

    private bool IsMarked(int vertical)
    {
        return marked[vertical];
    }

    public int Count()
    {
        return count;
    }
}

public class DepthFirstPath {
    private bool[] marked;//记录是否被dfs访问过
    private int[] edgesTo;//记录最后一个到当前节点的顶点
    private int begin;//搜索的起始点

    public DepthFirstPath(Graph g, int begin)
    {
        marked = new bool[g.GetVerticals];
        edgesTo = new int[g.GetVerticals];
        this.begin = begin;
        dfs(g, begin);
    }

    private void dfs(Graph g, int v)
    {
        marked[v] = true;
        foreach (var w in g.GetAdjacency(v))
        {
            if (!marked[w])
            {
                edgesTo[w] = v;
                dfs(g, w);
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

        for (int x = v; x!=s; x=edgesTo[x])
        {
            path.Push(x);
        }
        path.Push(s);
        return path;
    }
}

//图的邻接表表示形式
public class Graph {
    private readonly int verticals;//顶点个数
    private int edges;//边的个数
    private List<int>[] adjacency;//顶点联接列表

    public Graph(int verticals)
    {
        this.verticals = verticals;
        this.edges = 0;
        adjacency = new List<int>[verticals];
        for (int i = 0; i < verticals; i++)
        {
            adjacency[i] = new List<int>();
        }
    }

    public int GetVerticals()
    {
        return verticals;
    }

    public int GetEdges()
    {
        return edges;
    }

    public void AddEdge(int verticalStart, int verticalEnd)
    {
        adjacency[verticalStart].Add(verticalEnd);
        adjacency[verticalEnd].Add(verticalStart);
        edges++;
    }

    public List<int> GetAdjacency(int vertical)
    {
        return adjacency[vertical];
    }
}