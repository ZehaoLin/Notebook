//二叉树遍历

public class TreeNode 
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val) { this.val = val; }
}

public class BinaryTreeTraverse
{
    private TreeNode root;

    public TreeNode BuildBinaryTree(int[] nums)
    {
        if (nums.Length == 0 || nums == null) return null;
        int n = nums.Length;
        TreeNode node = new TreeNode(nums[0]);
        TreeNode cur = node;
        for (int i = 1; i < n; i++)
        {
            if (cur.left == null)
                cur.left = new TreeNode(nums[i]);
            else if (cur.right == null)
            {
                cur.right = new TreeNode(nums[i]);
                cur = cur.left;
            }
        }
        return node;
    }

    // 递归遍历
    private void PreTraverseByRecursion(TreeNode node)
    {
        if (node == null) return ;

        System.Console.Write(node.val + " ");
        if (node.left != null) 
            PreTraverseByRecursion(node.left);
        if (node.right != null)
            PreTraverseByRecursion(node.right);
    }

    private void InTraverseByRecursion(TreeNode node)
    {
        if (node == null) return ;

        if (node.left != null) 
            InTraverseByRecursion(node.left);
        System.Console.Write(node.val + " ");
        if (node.right != null)    
            InTraverseByRecursion(node.right);
    }

    private void BehTraverseBuRecursion(TreeNode node)
    {
        if (node == null) return ;

        if (node.left != null)
            BehTraverseBuRecursion(node.left);
        else if (node.right != null) 
            BehTraverseBuRecursion(node.right);
        System.Console.Write(node.val + " ");
    }

    //循环遍历
    private List PreTraverseByLoop(TreeNode node)
    {
        List<int> list = new List<int>();//输出链表
        if (node == null) return list;
        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode cur = node;

        while (cur != null || stack.Count > 0)
        {
            list.Add(node.val);//输出到链表

            if (cur != null)
            {
                stack.Push(cur);
                cur = cur.left;
            }
            else 
            {
                cur = stack.Pop();
                cur = cur.right;
            }
        }
        return list;
    }

    private void InTraverseByLoop(TreeNode node)
    {
        List<int> list = new List<int>();
        if (node == null) return list;
        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode cur = node;

        while (cur != null || stack.Count > 0)
        {
            if (cur != null)
            {
                stack.Push(cur);
                cur = cur.left;
            }
            else
            {
                cur = stack.Pop();
                list.Add(cur.val);
                cur = cur.right;
            }
        }
    }

    private void BehTraverseByLoop(TreeNode node)
    {
        List<int> list = new List<int>();
        if (node == null) return list;
        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode cur = node;

        while (cur != null && stack.Count > 1)
        {
            if (cur != null)
            {
                stack.Push(cur);
                cur = cur.left;
            }
            else
            {
                var item = stack.Peek();//读取栈顶 不弹出
                if (item.right != null && list.Contains(item.right.val) == false)
                {
                    cur = item.right;
                }
                else
                {
                    list.Add(item.val);
                    stack.Pop();
                }
            }
        }
    }

    //层序遍历
    public List<int> LevelOrderTraversion(TreeNode node)
    {
        List<int> list = new List<int>();
        if (node == null) return list;
        Queue<TreeNode> queue = new Queue<TreeNode>();
        
        TreeNode cur;
        queue.Enqueue(node);
        while (queue.Count > 0)
        {
            cur = queue.Dequeue();
            list.Add(cur.val);
            if (cur.left != null)
                queue.Enqueue(cur.left);
            if (cur.right != null)
                queue.Enqueue(cur.right);
        }
        return list;
    }
}