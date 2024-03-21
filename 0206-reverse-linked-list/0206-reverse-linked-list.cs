public class Solution {
    public ListNode ReverseList(ListNode head) {
        if(head == null || head.next == null) return head;

        ListNode prev = head, curr = head.next;
        prev.next = null;
        while(curr != null){
            var next = curr.next;
            curr.next = prev;
            prev = curr;
            curr = next;
        }

        return prev;
    }
}

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */