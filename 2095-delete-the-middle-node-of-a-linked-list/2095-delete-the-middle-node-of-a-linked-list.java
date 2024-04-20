public class Solution {
    public ListNode deleteMiddle(ListNode head) {
        var newHead = new ListNode(0, head);
        ListNode slow = newHead, fast = newHead.next;

        while(fast != null && fast.next != null){
            slow = slow.next;
            fast = fast.next.next;
        }

        slow.next = slow.next.next;
        return newHead.next;
    }
}