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
    public IList<int> InorderTraversal(TreeNode root) {
        List<int> list = new List<int>();
        if (root == null) return list;
        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode cur = root;

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

        return list;
    }
}