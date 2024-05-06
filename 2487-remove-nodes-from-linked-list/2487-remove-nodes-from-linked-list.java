class Solution {
    public ListNode removeNodes(ListNode head) {
        if(head == null) return head;
        head.next = removeNodes(head.next);
        if(head.next != null && head.val < head.next.val) return head.next;
        return head;
    }
}

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     int val;
 *     ListNode next;
 *     ListNode() {}
 *     ListNode(int val) { this.val = val; }
 *     ListNode(int val, ListNode next) { this.val = val; this.next = next; }
 * }
 */