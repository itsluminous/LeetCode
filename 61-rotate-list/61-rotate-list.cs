public class Solution {
    public ListNode RotateRight(ListNode head, int k) {
        if(head == null) return head;
        
        var len = 0;
        
        ListNode curr = head, tail = head;
        while(curr != null){
            len ++;
            tail = curr;
            curr = curr.next;
        }
        
        k %= len;
        if(k == 0) return head;
        
        curr = head;
        for(var i=0; i<len-k-1; i++)
            curr = curr.next;
        
        var next = curr.next;
        curr.next = null;
        tail.next = head;
        return next;
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