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
class Solution {
    public ListNode partition(ListNode head, int x) {
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