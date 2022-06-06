public class Solution {
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