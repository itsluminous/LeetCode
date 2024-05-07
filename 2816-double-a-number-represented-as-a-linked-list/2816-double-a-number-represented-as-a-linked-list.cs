public class Solution {
    public ListNode DoubleIt(ListNode head) {
        var carry = DoubleItt(head);
        if(carry > 0)
            head = new ListNode(carry, head);
        return head;
    }

    private int DoubleItt(ListNode node){
        if(node == null) return 0;
        var carry = DoubleItt(node.next);
        var num = carry + node.val * 2;
        node.val = num%10;
        carry = num / 10;
        return carry;
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