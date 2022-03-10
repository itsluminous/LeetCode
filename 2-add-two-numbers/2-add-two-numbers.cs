public class Solution {
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        var carry = 0;
        ListNode head = new ListNode(), tail = head;
        
        while(l1 != null && l2 != null){
            var curr = carry + l1.val + l2.val;
            carry = curr / 10;
            tail.next = new ListNode(curr%10);
            tail = tail.next;
            l1 = l1.next;
            l2 = l2.next;
        }
        
        while(l1 != null){
            var curr = carry + l1.val;
            carry = curr / 10;
            tail.next = new ListNode(curr%10);
            tail = tail.next;
            l1 = l1.next;
        }
        
        while(l2 != null){
            var curr = carry + l2.val;
            carry = curr / 10;
            tail.next = new ListNode(curr%10);
            tail = tail.next;
            l2 = l2.next;
        }
        
        if(carry != 0)
            tail.next = new ListNode(carry);
        
        return head.next;
    }
}

// Accepted
public class Solution1 {
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        var prev = new ListNode(0);
        var head = prev;
        int carry = 0;
        while (l1 != null || l2 != null || carry != 0) {
            var current = new ListNode(0);
            int sum = ((l2 == null) ? 0 : l2.val) + ((l1 == null) ? 0 : l1.val) + carry;
            current.val = sum % 10;
            carry = sum / 10;
            prev.next = current;
            prev = current;
            
            l1 = (l1 == null) ? l1 : l1.next;
            l2 = (l2 == null) ? l2 : l2.next;
        }
        return head.next;
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