public class Solution {
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