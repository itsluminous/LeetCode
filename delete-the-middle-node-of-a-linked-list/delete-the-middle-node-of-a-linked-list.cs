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
public class Solution {
    public ListNode DeleteMiddle(ListNode head) {
        if(head == null || head.next == null) return null;
        ListNode slow=head, fast = head.next, slowPrev = head;
        while(fast != null && fast.next != null){
            slowPrev = slow;
            slow = slow.next;
            fast = fast.next.next;
        }
        if(fast == null)
            slowPrev.next = slow.next;
        else
            slow.next = slow.next.next;
        return head;
    }
}