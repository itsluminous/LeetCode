public class Solution {
    public ListNode SortList(ListNode head) {
        if (head == null || head.next == null) return head;
        
        var mid = GetMid(head);
        var left = SortList(head);  // this may look like infinite loop, but GetMid() splits list into two
        var right = SortList(mid);
        return Merge(left, right);
    }
    
    ListNode Merge(ListNode head1, ListNode head2){
        var head = new ListNode();
        var tail = head;
        while(head1 != null && head2 != null){
            if(head1.val < head2.val){
                tail.next = head1;
                tail = tail.next;
                head1 = head1.next;
            }
            else{
                tail.next = head2;
                tail = tail.next;
                head2 = head2.next;
            }
        }
        tail.next = head1 == null ? head2 : head1;
        return head.next;
    }
    
    ListNode GetMid(ListNode fast){
        ListNode slow = null;
        while(fast != null && fast.next != null){
            slow = slow == null ? fast : slow.next;
            fast = fast.next.next;
        }
        var mid = slow.next;
        slow.next = null;        // we are splitting the list at this point
        return mid;
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