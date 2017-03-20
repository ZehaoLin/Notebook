/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
 //最长路径 最大深度
public class Solution {
    public int MaxDepthByDfs(TreeNode root) {
        if (root == null) return 0;
        TreeNode curNode = root;
        Stack<TreeNode> stack = new Stack<TreeNode>();
        Stack<TreeNode> depthStack = new Stack<TreeNode>();
        int max = 0;
        int depth = 1;
        while (stack != null || stack.Count > 0) 
        {
            if (curNode != null) 
            {
                stack.Push(curNode);
                depthStack.Push(depth);
                curNode = curNode.left;
                depth++;
            }
            else 
            {
                curNode = stack.Pop();
                depth = depthStack.Pop();
                curNode = curNode.right;

                if (depth > max) max = depth;
                depth++;
            }
        }

        return max;
    }

    public int MaxDepthByBfs(TreeNode root) {
        if (root == null) return 0;
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        int ret = 0;
        while (queue.Count > 0)
        {
            int size = queue.size();
            while (size-- > 0)
            {
                TreeNode node = queue.Dequeue();
                if (node.left != null)
                    queue.Enqueue(node.left);
                if (node.right != null)
                queue.Enqueue(node.right);
            }
            ret++;
        }

        return ret;
    }

    public int MaxDepthByRecursion(TreeNode root) {
        if (root == null) return 0;
        return Math.Max(MaxDepthByRecursion(root.left), MaxDepthByRecursion(root.right)) + 1;
    }
}