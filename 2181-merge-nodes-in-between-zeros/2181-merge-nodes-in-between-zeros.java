class Solution {
    public ListNode mergeNodes(ListNode head) {
        var mergeHead = new ListNode(-1);   // temp head
        var mergePtr = mergeHead;
        head = head.next;

        var curr = 0;
        while(head != null){
            if(head.val == 0){
                var node = new ListNode(curr);
                mergePtr.next = node;
                mergePtr = mergePtr.next;
                curr = 0;
            }
            else curr += head.val;
            head = head.next;
        }

        return mergeHead.next;
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