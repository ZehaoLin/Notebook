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
    public bool IsValidBST(TreeNode root) {
        //输入为空 return true
        //输入为1元素 return true
        return IsValidBST(root, long.MaxValue, long.MinValue);
    }

    public bool IsValidBST(TreeNode root, long max, long min)
    {
        if (root == null) return true;

        return  root.val > min &&
                root.val < max &&
                IsValidBST(root.left, root.val, min) &&
                IsValidBST(root.right, max, root.val);
    }
}