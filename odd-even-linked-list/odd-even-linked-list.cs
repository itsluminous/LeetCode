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
    public ListNode OddEvenList(ListNode head) {
        if(head == null) return head;

        ListNode temp = head, odd = new ListNode(-1), oddStart = odd, even = new ListNode(-1), evenStart = even;
        var idx=1;
        while(temp != null){
            if(idx % 2 == 0){
                even.next = temp;
                even = even.next;
            }   
            else{
                odd.next = temp;
                odd = odd.next;
            }
            temp = temp.next;
            idx++;
        }
        even.next = null;
        odd.next = evenStart.next;
        return oddStart.next;
    }
}