class Solution {
    public int getDecimalValue(ListNode head) {
        var ans = 0;
        while(head != null){
            ans <<= 1;
            ans |= head.val;
            head = head.next;
        }
        return ans;
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