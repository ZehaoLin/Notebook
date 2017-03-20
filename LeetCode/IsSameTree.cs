/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public bool IsSameTree(TreeNode p, TreeNode q) {
        if (p == null && q == null) return true;
        if (p != null && q != null && p.val == q.val) 
            return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);

        return false; 
    }

    public bool IsSameTree(TreeNode p, TreeNode q) {
        if (p == null && q == null) return true;
        Stack<TreeNode> stack_q = new Stack<TreeNode>();
        Stack<TreeNode> stack_p = new Stack<TreeNode>();
        TreeNode p_node;
        TreeNode q_node;

        stack_p.Push(p);
        stack_q.Push(q);
        while (stack_p.Count > 0 && stack_q.Count > 0)
        {
            p_node = stack_p.Pop();
            q_node = stack_q.Pop();
            if (p_node.val != q_node.val) return false;
            if (p_node.left != null) stack_p.Push(p_node.left);
            if (q_node.left != null) stack_q.Push(q_node.left);
            if (stack_p.Count != stack_q.Count) return false;
            if (p_node.right != null) stack_p.Push(p_node.right);
            if (q_node.right != null) stack_q.Push(q_node.right);
            if (stack_p.Count != stack_q.Count) return false;
        }

        return stack_p.Count == stack_q.Count;
    }
}