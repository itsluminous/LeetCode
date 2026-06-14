class Solution {
    public int pairSum(ListNode head) {
        var firstHalf = new Stack<Integer>();
        ListNode slow = head, fast = head;

        // reach half point
        while(fast != null && fast.next != null){
            firstHalf.push(slow.val);
            slow = slow.next;
            fast = fast.next.next;
        }

        // find max
        var ans = 0;
        while(slow != null){
            ans = Math.max(ans, slow.val + firstHalf.pop());
            slow = slow.next;
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