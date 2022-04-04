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
    public ListNode SwapNodes(ListNode head, int k) {
        ListNode curr = head;
        
        // find length of linked list
        var n = 1;
        while(curr.next != null){
            n++;
            curr = curr.next;
        }
           
        // find node from left that needs swapping
        curr = head;
        for(var i=1; i<k; i++)
            curr = curr.next;
        
        // find node from right that needs swapping
        var second = head;
        for(var i=0; i<n-k; i++)
            second = second.next;
        
        // swap the nodes
        var temp = curr.val;
        curr.val = second.val;
        second.val = temp;
        
        return head;
    }
}