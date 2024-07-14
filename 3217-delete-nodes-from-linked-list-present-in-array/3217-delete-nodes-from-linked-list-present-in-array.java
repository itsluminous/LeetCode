class Solution {
    public ListNode modifiedList(int[] nums, ListNode head) {
        var hs = new HashSet<Integer>();
        for(var num : nums)
            hs.add(num);

        var newHead = new ListNode(-1, head);
        var curr = newHead;;
        while(curr.next != null){
            if(hs.contains(curr.next.val)){
                curr.next = curr.next.next;
            }
            else{
                curr = curr.next;
            }
        }
        return newHead.next;
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