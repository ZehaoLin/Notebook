/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     int val;
 *     ListNode next;
 *     ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode removeNthFromEnd(ListNode head, int n) {
        if (n < 1 || head == null) return head;
        /**
            first指针先走到第n个节点，second指针开始走，first和second指针的间距差为n
            但first达到最后一个元素时，second指针指向的正好是要删除的节点
            注意空指针
         */
        int cnt = 1;
        ListNode first = head;
        ListNode second = head;
        ListNode pre = null;

        while (first != null) {
            first = first.next;
            if (cnt > n) {
                pre = second;
                second = second.next;
            }
            cnt++;
        }

        if (second == head) return head.next;
        pre.next = second.next;   
        return head;
    }
}