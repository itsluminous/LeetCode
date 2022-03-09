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
public class Solution {
    public ListNode DeleteDuplicates(ListNode head) {
        if(head == null || head.next == null) return head;
        
        ListNode start = new ListNode(), tail = start;
        ListNode prev = head, curr = head.next;
        var duplicateVal = -999;
        while(curr != null){
            // Console.WriteLine($"prev={prev.val}, curr={curr.val}, duplicateVal={duplicateVal}");
            if(prev.val == curr.val)
                duplicateVal = curr.val;
            else if(prev.val != duplicateVal){
                duplicateVal = -999;
                tail.next = prev;
                tail = tail.next;
            }
            
            prev = curr;
            curr = curr.next;
            continue;
        }
        
        if(prev.val != duplicateVal){
            tail.next = prev;
            tail = tail.next;
        }
            
        tail.next = null;
        return start.next;
    }
}