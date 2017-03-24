/**
 * 逆向输出链表
 * 题目：输入一个链表的头结点，从尾到头反过来打印每一个节点的值
 */
public class Solution {
    class ListNode {
        ListNode next;
        int val;
        public ListNode(int val) { this.val = val; }
    }

    public void printListReversingly(ListNode head) {
        Stack<ListNode> stack = new Stack<>();
        ListNode node = head;

        while (node != null) {
            stack.push(node);
            node = node.next;
        }

        while (stack.isEmpty() == false) {
            node = stack.peek();
            System.out.print(node.val);
            stack.pop();
        }
    }
}