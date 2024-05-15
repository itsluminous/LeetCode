public class Solution {
    public ListNode InsertGreatestCommonDivisors(ListNode head) {
        if(head == null || head.next == null) return head;
        
        var curr = head;
        while(curr.next != null){
            var next = curr.next;
            var gcdVal = GCD(curr.val, next.val);
            var gcdNode = new ListNode(gcdVal, next);
            curr.next = gcdNode;
            curr = next;
        }

        return head;
    }

    private int GCD(int a, int b)
    {
        // ensure that b is always smaller
        if(b > a) return GCD(b, a);

        while (b != 0)
        {
            var temp = b;
            b = a % b;
            a = temp;
        }
        return a;
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