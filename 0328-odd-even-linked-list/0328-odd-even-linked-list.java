public class Solution {
    public ListNode oddEvenList(ListNode head) {
        if(head == null || head.next == null) return head;
        ListNode oddTail = head, evenHead = head.next, evenTail = head.next;

        while(evenTail != null && evenTail.next != null){
            oddTail.next = oddTail.next.next;
            evenTail.next = evenTail.next.next;

            oddTail = oddTail.next;
            evenTail = evenTail.next;
        }

        oddTail.next = evenHead;
        return head;
    }
}