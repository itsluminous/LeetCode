class Solution {
    public ListNode addTwoNumbers(ListNode l1, ListNode l2) {
        ListNode ans = new ListNode(-1), curr = ans;
        int carry = 0, num = 0;

        while(l1 != null || l2 != null){
            var nc = sum(l1, l2, carry);
            num = nc[0]; carry = nc[1];
            curr.next = new ListNode(num);

            curr = curr.next;
            if(l1 != null) l1 = l1.next;
            if(l2 != null) l2 = l2.next;
        }

        if(carry == 1) curr.next = new ListNode(1);
        return ans.next;
    }

    private int[] sum(ListNode l1, ListNode l2, int carry){
        int num1 = 0, num2 = 0;
        if(l1 != null) num1 = l1.val;
        if(l2 != null) num2 = l2.val;

        var num = num1 + num2 + carry;
        if(num <= 9) carry = 0;
        else{
            carry = 1;
            num -= 10;
        }
        return new int[]{num, carry};
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