class Solution {
    public ListNode doubleIt(ListNode head) {
        var carry = doubleItt(head);
        if(carry > 0) head = new ListNode(carry, head);
        return head;
    }

    private int doubleItt(ListNode node){
        if(node == null) return 0;
        var carry = doubleItt(node.next);
        var num = carry + node.val * 2;
        node.val = num%10;
        carry = num / 10;
        return carry;
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