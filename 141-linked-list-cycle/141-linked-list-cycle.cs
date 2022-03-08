public class Solution {
    public bool HasCycle(ListNode head) {
        if(head == null || head.next == null) return false;
        
        ListNode slow = head, fast = head;
        while(fast.next != null && fast.next.next != null){
            slow = slow.next;
            fast = fast.next.next;
            
            if(slow == fast) return true;
        }
        
        return false;
    }
}

// Accepted
public class Solution1 {
    public bool HasCycle(ListNode head) {
        if(head == null) return false;
        var slow = head;
        var fast = head.next;
        
        while(fast!= null){
            if(slow == fast) return true;
            if(fast.next == null) return false;
            slow = slow.next;
            fast = fast.next.next;
        }
        return false;
    }
}

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {
 *         val = x;
 *         next = null;
 *     }
 * }
 */