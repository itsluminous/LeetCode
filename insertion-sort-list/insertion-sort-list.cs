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
    public ListNode InsertionSortList(ListNode head) {
        // base validation
        if (head == null) return head;
        
        // initialise required variables
        ListNode result = new ListNode(-1), curr = head, prev = result, next = null;
        
        // loop through each node
        while(curr != null){
            next = curr.next;
            
            // find the right place (looping from left to right)
            while(prev.next != null && prev.next.val < curr.val)
                prev = prev.next;
            
            // insert node
            curr.next = prev.next;
            prev.next = curr;
            
            // initialize variables for next iteration
            prev = result;
            curr = next;
        }
        
        return result.next;
    }
}