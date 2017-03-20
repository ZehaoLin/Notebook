/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode ReverseList(ListNode head) {
        if (head == null || head.next == null) return head;
        Stack<ListNode> stack = new Stack<ListNode>();

        while (head != null) 
        {
            stack.Push(head);
            head = head.next;
        }

        ListNode retList = new ListNode(stack.Pop().val);
        ListNode curNode = retList;
        while (stack.Count > 0)
        {
            curNode.next = new ListNode(stack.Pop().val);
            curNode = curNode.next;
        }
        curNode.next = null;
        
        return retList;
    }
}