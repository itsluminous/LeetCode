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
    public ListNode MergeNodes(ListNode head) {
        if(head == null || head.val != 0) return head;
        ListNode curr = head.next, start = head.next, root = start;
        while(curr != null){
            // for first case we would have already counted the val, so don't add it again
            if(start != curr) start.val += curr.val;
            
            // if we found end of current consecutive lists
            if(curr.val == 0){
                start.next = curr.next;
                start = curr.next;
            }
            
            curr = curr.next;
        }
        
        return root;
    }
}