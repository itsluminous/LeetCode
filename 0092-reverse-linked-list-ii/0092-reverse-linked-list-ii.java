class Solution {
    public ListNode reverseBetween(ListNode head, int left, int right) {
        if(left == right) return head;
        right -= left - 1;

        var newHead = new ListNode(-1, head);
        var curr = newHead;

        // find out the left node
        while(--left > 0)
            curr = curr.next;
        ListNode leftPrev = curr, leftNode = curr.next;
        
        // reverse uptill we find right node
        var prev = curr;
        curr = curr.next;
        while(right-- > 0){
            var nextPtr = curr.next;
            curr.next = prev;
            prev = curr;
            curr = nextPtr;
        }

        // fix missing links
        leftPrev.next = prev;
        leftNode.next = curr;

        return newHead.next;
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