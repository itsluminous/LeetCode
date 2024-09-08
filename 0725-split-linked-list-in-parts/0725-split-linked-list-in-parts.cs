public class Solution {
    public ListNode[] SplitListToParts(ListNode head, int k) {
        if(head == null) return new ListNode[k];
        var ans = new ListNode[k];

        // count length of linked list
        var len = 0;
        var curr = head;
        while(curr != null){
            curr = curr.next;
            len++;
        }

        var minSize = len / k;
        var extraCount = len % k;

        // add all lists with extra nodes
        for(var ansIdx=0; ansIdx < extraCount; ansIdx++){
            ans[ansIdx] = head;
            var prev = head;
            for(var i=0; i<=minSize; i++){
                prev = head;
                head = head.next;
            }

            prev.next = null;
        }

        // add all lists with min nodes
        for(var ansIdx=extraCount; ansIdx < k && head != null; ansIdx++){
            ans[ansIdx] = head;
            var prev = head;
            for(var i=0; i<minSize; i++){
                prev = head;
                head = head.next;
            }

            prev.next = null;
        }

        return ans;
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