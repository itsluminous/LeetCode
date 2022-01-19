/*
If there is a cycle,
L1 is defined as the distance between the head point and cycle start point
L2 is defined as the distance between the cycle start point and the meeting point of slow and fast
n is defined as length of meeting point to start of the cycle.
Cycle total length would be n + L2

so, slow has travelled L1+L2
and, fast has travelled L1 + L2 + n + L2

we know that fast pointer has travelled twice that of slow, so
=> 2(L1 + L2) = L1 + L2 + n + L2
=> 2L1 + 2L2 = L1 + 2L2 + n
=> L1 = n;

i.e. distance from 0 to meeting point  is same as meeting point to start of cycle
*/
public class Solution1 {
    public ListNode DetectCycle(ListNode head) {
        //base case
        if(head == null || head.next == null) return null;
        // initialize variables
        ListNode slow = head, fast = head, start = head;
        // iterate with slow and fast pointers
        while(fast.next != null && fast.next.next != null){
            slow = slow.next;
            fast = fast.next.next;
            // if found a cycle
            if(slow == fast){
                while(start != slow){
                    slow = slow.next;
                    start = start.next;
                }
                return start;
            }
        }
        return null;
    }
}

// using hash set
public class Solution {
    public ListNode DetectCycle(ListNode head) {
        var set = new HashSet<ListNode>();
        var node = head;
        while(node != null){
            if(!set.Add(node)) return node;
            node = node.next;
        }
        return null;
    }
}

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {
 *         val = x;
 *         next = null;
 *     }
 * }
 */