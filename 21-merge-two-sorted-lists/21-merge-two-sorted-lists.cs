public class Solution {
    public ListNode MergeTwoLists(ListNode l1, ListNode l2) {
        ListNode result = new ListNode(0);
        var head = result;
        while(l1 != null && l2 != null){
            if(l1.val < l2.val){
                result.next = l1;
                l1 = l1.next;
            }
            else{
                result.next = l2;
                l2 = l2.next;
            }
            result = result.next;
        }
        
        // add remaining nodes
        if(l1 != null) result.next = l1;
        if(l2 != null) result.next = l2;
        
        return head.next;
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