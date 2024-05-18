public class Solution {
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        ListNode ans = new ListNode(-1), curr = ans;
        int carry = 0, num = 0;

        while(l1 != null || l2 != null){
            (num, carry) = Sum(l1, l2, carry);
            curr.next = new ListNode(num);

            curr = curr.next;
            if(l1 != null) l1 = l1.next;
            if(l2 != null) l2 = l2.next;
        }

        if(carry == 1) curr.next = new ListNode(1);
        return ans.next;
    }

    private (int, int) Sum(ListNode l1, ListNode l2, int carry){
        int num1 = 0, num2 = 0;
        if(l1 != null) num1 = l1.val;
        if(l2 != null) num2 = l2.val;

        var num = num1 + num2 + carry;
        if(num <= 9) carry = 0;
        else{
            carry = 1;
            num -= 10;
        }
        return (num, carry);
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