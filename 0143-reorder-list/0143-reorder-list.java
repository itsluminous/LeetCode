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
class Solution {
    public void reorderList(ListNode head) {
        var stack = new Stack<ListNode>();
        
        // find mid
        ListNode slow = head, fast = head;
        while(fast != null && fast.next != null){
            stack.push(slow);
            slow = slow.next;
            fast = fast.next.next;
        }

        ListNode right = slow, next = null;
        // handle odd nodes in list
        if(fast != null){
            next = slow;
            right = slow.next;
            next.next = null;   // last node will always have next as null
        }

        // now do the mapping
        while(stack.size() > 0){
            var left = stack.pop();
            
            // attach right to node in stack
            left.next = right;
            right = right.next;
            
            // set next node appropriately
            left.next.next = next;
            next = left;
        }
    }
}