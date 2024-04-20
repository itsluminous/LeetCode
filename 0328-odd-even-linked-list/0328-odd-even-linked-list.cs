public class Solution {
    public ListNode OddEvenList(ListNode head) {
        if(head == null || head.next == null) return head;
        ListNode oddTail = head, evenHead = head.next, evenTail = head.next;
        
        var fillOdd = true;
        var curr = head.next.next;
        while(curr != null){
            if(fillOdd){
                oddTail.next = curr;
                oddTail = curr;
            }
            else{
                evenTail.next = curr;
                evenTail = curr;
            }

            curr = curr.next;
            fillOdd = !fillOdd;
        }

        oddTail.next = evenHead;
        evenTail.next = null;
        return head;
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