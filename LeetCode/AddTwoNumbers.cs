/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        ListNode listNode = new ListNode(0);
        ListNode t1 = l1, t2= l2;
        ListNode tmp = listNode;
        int carry = 0;

        while (t1 != null || t2 != null)
        {
            int x = (t1 != null) ? t1.val : 0;
            int y = (t2 != null) ? t2.val : 0;
            int sum = x + y + carry;

            carry = sum / 10;
            tmp.next = new ListNode(sum % 10);
            tmp = tmp.next;
            if (t1 != null) t1 = t1.next;
            if (t2 != null) t2 = t2.next;
        }

        if (carry > 0)
            tmp.next = new ListNode(carry);

        return listNode.next;
    }
}