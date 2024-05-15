class Solution {
    public ListNode insertGreatestCommonDivisors(ListNode head) {
        if(head == null || head.next == null) return head;
        
        var curr = head;
        while(curr.next != null){
            var next = curr.next;
            var gcdVal = gcd(curr.val, next.val);
            var gcdNode = new ListNode(gcdVal, next);
            curr.next = gcdNode;
            curr = next;
        }

        return head;
    }

    private int gcd(int a, int b)
    {
        // ensure that b is always smaller
        if(b > a) return gcd(b, a);

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
 *     int val;
 *     ListNode next;
 *     ListNode() {}
 *     ListNode(int val) { this.val = val; }
 *     ListNode(int val, ListNode next) { this.val = val; this.next = next; }
 * }
 */