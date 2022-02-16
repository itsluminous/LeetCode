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
    public ListNode SwapPairs(ListNode head) {
        var prev = new ListNode();
        var start = prev;
        
        var curr = head;
        while(curr != null && curr.next != null){
            var next = curr.next.next;
            prev.next = curr.next;
            curr.next.next = curr;
            prev = curr;
            curr = next;
        }
        
        prev.next = curr;
        return start.next;
    }
}