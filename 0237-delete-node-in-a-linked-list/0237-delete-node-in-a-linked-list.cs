public class Solution {
    public void DeleteNode(ListNode node) {
        node.val = node.next.val;
        if(node.next.next == null) node.next = null;
        else DeleteNode(node.next);
    }
}

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */