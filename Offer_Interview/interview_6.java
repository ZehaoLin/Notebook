/**
 * 重建二叉树
 * 题目：输入某二叉树的前序遍历和中序遍历的结果，请重建出该二叉树。假设输入的前序遍历和中序遍历的结果中都不含重复的数字。
 */
public class Solution {
    
    class BinaryTreeNode {
        int val;
        BinaryTreeNode left;
        BinaryTreeNode right;
        public BinaryTreeNode(int val) { this.val = val; }
    }

    public BinaryTreeNode construct(int[] preorder, int[] inorder) {
        if (preorder == null || inorder == null || preorder.length <= 0 || inorder.length <= 0 || inorder.left != preorder.length)
            return null;
        return construct(int[] preorder,int[] inorder, 0, preorder.length - 1, 0, inorder.length - 1);
    }

    public BinaryTreeNode construct(int[] preorder, int[] inorder, int startPre, int endPre, int startIn, int endIn) {
        //前序遍历序列的第一个元素时根节点的值
        int rootValue = preorder[startPre];
        BinaryTreeNode root = new BinaryTreeNode(rootValue);
        root.left = root.right = null;

        //在中序遍历中找到根节点的值
        int rootInorder = startIn;
        while (rootInorder <= endIn && inorder[rootInorder] != rootValue)
            ++ rootInorder;
        if (rootInorder == endIn && inorder[rootInorder] != rootValue)//没找到
            throw new Exception("Invalid input.");

        if (startPre == endPre) {
            if (startIn == endIn && preorder[startPre] == inorder[startIn]) {
                return root;
            } else {
                throw new Exception("Invalid input");
            }
        }

        //递归重建
        int leftLength = rootInorder - startIn;
        int leftPreorderEnd = startPre + leftLength;//左边树的结尾
        if (leftLength > 0) {//构建左子树
            root.left = construct(int[] preorder, int[] inorder, startPre + 1, leftPreorderEnd, startIn, rootInorder - 1);
        } 
        if (leftLength < endPre - startPre) {//构建右子树
            root.right = construct(int[] preorder, int[] inorder, leftPreorderEnd + 1, endPre, rootInorder + 1, endIn);
        }

        return root;
    }
}