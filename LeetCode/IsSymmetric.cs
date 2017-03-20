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
    public bool IsSymmetric(TreeNode root) {
        if (root == null) return true;
        Queue<TreeNode> queue = new Queue<TreeNode>();
        
        queue.Enqueue(root.left);     
        queue.Enqueue(root.right);
        while (queue.Count > 0)
        {
            //对称比较 
            TreeNode left = queue.Dequeue();
            TreeNode right = queue.Dequeue();
            if (left == null && right == null) continue;//两边对称为空
            if (left == null || right == null) return false;//两边不对称
            if (left.val != right.val) return false;//两边都有元素，但是元素不一致
            //两边都有元素且一致
            //对称入队
            queue.Enqueue(left.left);
            queue.Enqueue(right.right);
            queue.Enqueue(left.right);
            queue.Enqueue(right.left);
        }

        return true;
    }
}