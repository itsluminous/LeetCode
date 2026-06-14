
public class Solution {
    public int PairSum(ListNode head) {
        var firstHalf = new Stack<int>();
        ListNode slow = head, fast = head;

        // reach half point
        while(fast != null && fast.next != null){
            firstHalf.Push(slow.val);
            slow = slow.next;
            fast = fast.next.next;
        }

        // find max
        var ans = 0;
        while(slow != null){
            ans = Math.Max(ans, slow.val + firstHalf.Pop());
            slow = slow.next;
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