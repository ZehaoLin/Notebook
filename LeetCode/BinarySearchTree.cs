// TKey 用于排序
// TValue 节点所包含的值
// Number 记录所有子节点的个数
public class BinarySearchTreeSymbolTables<TKey, TValue> : SymbolTables<TKey, TValue> 
                where TKey: IComparable<TKey>, IEquatable<TValue>
{
    private Node root;
    private class Node
    {
        public Node Left { get; set; }
        public Node Right { get; set; }
        public int Number { get; set; }
        public TKey Key { get; set; }
        public TValue Value { get; set; }

        public Node(TKey key, TValue value, int number)
        {
            this.Value = value;
            this.Key = key;
            this.Number = number;
        }
    }

    //查找
    public override TValue Get(TKey key)
    {
        TValue result = default(TValue);
        Node node = root;
        while (node != null)
        {
            if (key.CompareTo(node.Key) > 0)
                node = node.Right;
            else if (key.CompareTo(node.Key) < 0)
                node = node.Left;
            else 
                return node.Value;
        }

        return result;
    }

    //插入
    public override void Put(TKey, TValue value)
    {
        root = Put(root, key, vbalue);
    }

    public Node Put(Node x, TKey key, TValue value)
    {
        //如果节点为空，则创建新的节点，并返回
        //否则比较根据大小判断是左节点还是右节点，然后继续查找左子树还是右子树
        //同时更新节点的Number的值
        if (x == null) return new Node(key, value, 1);
        int cmp = key.CompareTo(x.Key);
        if (cmp < 0) x.Left = Put(x.Key, key, value);
        else if (cmp > 0) x.Right = Put(x.Right, key, valye);
        else x.Value = value;
        x.Number = Size(x.Left) + Size(x.Right) + 1;
        return x;
    }

    private int Size(Node node)
    {
        if (node == null) return 0;
        else return node.Number;
    }

    public override TKey GetMax()
    {
        TKey maxItem = default(TKey);
        Node s = root;
        while (s.Right != null)
        {
            s = s.Right;
        }
        maxItem = s.Key;
        return maxItem;
    }

    public override TKey GetMin()
    {
        TKey minItem = default(TKey);
        Node s = root;
        while (s.Left != null)
        {
            s = s.Left;
        }
        minItem = s.Key;
        return minItem;
    }

    public void DelMin()
    {
        root = DelMin(root);
    }

    private Node DelMin(Node root)
    {
        if (root.Left == null) return root.Right;
        root.Left = DelMin(root.Left);
        root.Number = Size(root.Left) + Size(root.Right) + 1;
        return root;
    }

    public void Delete(TKey key)
    {
        root =Delete(root, key);
            
    }

    private Node Delete(Node x, TKey key)
    {
        int cmp = key.CompareTo(x.Key);
        if (cmp > 0) x.Right = Delete(x.Right, key);
        else if (cmp < 0) x.Left = Delete(x.Left, key);
        else
        {
            if (x.Left == null) return x.Right;
            else if (x.Right == null) return x.Left;
            else
            {
                Node t = x;
                x = GetMinNode(t.Right);
                x.Right = DelMin(t.Right);
                x.Left = t.Left;
            }
        }
        x.Number = Size(x.Left) + Size(x.Right) + 1;
        return x;
    }

    private Node GetMinNode(Node x)
    {
        if (x.Left == null) return x;
        else return GetMinNode(x.Left); 
    }
}