// maintain two lists - for small nodes and for large nodes
// at the end, join the two lists
public class Solution {
    public ListNode Partition(ListNode head, int x) {
        var newHeadSmall = new ListNode(-1);
        var newHeadLarge = new ListNode(-1);
        ListNode smallPtr = newHeadSmall, largePtr = newHeadLarge;

        while(head != null){
            if(head.val < x){
                smallPtr.next = head;
                smallPtr = smallPtr.next;
            }
            else{
                largePtr.next = head;
                largePtr = largePtr.next;
            }
            head = head.next;
        }

        largePtr.next = null;   // end the list
        smallPtr.next = newHeadLarge.next;  // join the two lists

        return newHeadSmall.next;
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