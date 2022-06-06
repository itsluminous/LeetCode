// Without using any extra space
// Explaination - https://leetcode.com/problems/intersection-of-two-linked-lists/discuss/49785/Java-solution-without-knowing-the-difference-in-len!/165648

public class Solution {
    public ListNode GetIntersectionNode(ListNode headA, ListNode headB) {
        if(headA == null || headB == null) return null;
        ListNode a = headA, b = headB;
        
        while(a != b){
            // if a or b reaches end then point them to head of alternate list.
            // this way, the difference in length of the lists will be offset
            a = a == null ? headB : a.next;
            b = b == null ? headA : b.next;
        }
        
        return a;
    }
}

// Accepted - using hashset
public class Solution1 {
    public ListNode GetIntersectionNode(ListNode headA, ListNode headB) {
        var set = new HashSet<ListNode>();
        ListNode a = headA, b = headB;
        
        while(a != null){
            set.Add(a);
            a = a.next;
        }
        
        while(b != null){
            if(set.Contains(b))
                return b;
            b = b.next;
        }
        
        return null;
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