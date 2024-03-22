public class Solution {
    public bool IsPalindrome(ListNode head) {
        ListNode slow = head, fast = head;
        while(fast != null && fast.next != null){
            slow = slow.next;
            fast = fast.next.next;
        }
        if(fast != null) slow = slow.next;

        ListNode left = head, right = Reverse(slow);
        while(right != null){
            if(left.val != right.val) return false;
            left = left.next;
            right = right.next;
        }
        return true;
    }

    private ListNode Reverse(ListNode head){
        ListNode prev = null;
        while(head != null){
            var next = head.next;
            head.next = prev;
            prev = head;
            head = next;
        }
        return prev;
    }
}

// Accepted - using extra space complexity
public class SolutionSB {
    public bool IsPalindrome(ListNode head) {
        var sb = new StringBuilder();
        while(head != null){
            sb.Append(head.val);
            head = head.next;
        }
        
        var str = sb.ToString();
        for(int i=0, j=str.Length-1; i<j; i++,j--)
            if(str[i] != str[j]) return false;
        return true;
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