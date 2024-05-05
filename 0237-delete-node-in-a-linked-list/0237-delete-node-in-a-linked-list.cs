public class Solution {
    public void DeleteNode(ListNode node) {
        var temp = node.next;
        node.val = temp.val;
        node.next = temp.next;
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