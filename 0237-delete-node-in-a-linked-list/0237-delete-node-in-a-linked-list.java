class Solution {
    public void deleteNode(ListNode node) {
        var temp = node.next;
        node.val = temp.val;
        node.next = temp.next;
    }
}

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     int val;
 *     ListNode next;
 *     ListNode(int x) { val = x; }
 * }
 */