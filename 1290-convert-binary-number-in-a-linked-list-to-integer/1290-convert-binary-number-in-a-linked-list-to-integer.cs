public class Solution {
    public int GetDecimalValue(ListNode head) {
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
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */