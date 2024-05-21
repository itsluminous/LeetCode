class Solution {
    public ListNode rotateRight(ListNode head, int k) {
        ListNode slow = head, fast = head;
        var n = 0;

        // count total nodes
        while(fast != null){
            fast = fast.next;
            n++;
        }

        if(n == 0) return head;
        k = k % n;

        // move slow ptr to (n-k) and fast to nth node
        fast = head;
        while(k-- != 0) fast = fast.next;

        while(fast.next != null){
            slow = slow.next;
            fast = fast.next;
        }

        fast.next = head;
        head = slow.next;
        slow.next = null;

        return head;
    }
}

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