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
    public void ReorderList(ListNode head) {
        // save all nodes in stack
        var stack = new Stack<ListNode>();
        var curr = head.next;
        while(curr != null){
            stack.Push(curr);
            curr = curr.next;
        }
        
        var half = stack.Count/2;
        
        curr = head;
        for(var i=0; i<=half && stack.Count > 0; i++){
            var next = i==half ? null : curr.next;  // set null for last node
            curr.next = stack.Pop();
            curr.next.next = next;
            curr = next;
        }
    }
}