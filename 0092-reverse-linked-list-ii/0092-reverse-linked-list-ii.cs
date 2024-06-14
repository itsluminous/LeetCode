public class Solution {
    public ListNode ReverseBetween(ListNode head, int left, int right) {
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
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */