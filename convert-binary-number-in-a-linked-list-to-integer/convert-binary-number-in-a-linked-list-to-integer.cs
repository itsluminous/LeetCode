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
public class Solution
{
    public int GetDecimalValue(ListNode head)
    {
        var curr = head;
        int length = 0;
		//first pass: get length of linked list
        while (curr != null)
        {
            length++;
            curr = curr.next;
        }

        int res = 0;
        int i = 1;
        curr = head;
        while (curr != null)
        {
            res |= (curr.val << (length - i++));
            curr = curr.next;
        }

        return res;
    }
}