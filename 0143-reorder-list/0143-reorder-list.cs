public class Solution {
    public void ReorderList(ListNode head) {
        var stack = new Stack<ListNode>();
        
        // find mid
        ListNode slow = head, fast = head;
        while(fast != null && fast.next != null){
            stack.Push(slow);
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
        while(stack.Count > 0){
            var left = stack.Pop();
            
            // attach right to node in stack
            left.next = right;
            right = right.next;
            
            // set next node appropriately
            left.next.next = next;
            next = left;
        }
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