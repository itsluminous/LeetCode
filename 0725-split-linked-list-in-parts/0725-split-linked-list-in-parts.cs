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
        head = AddNodes(ans, head, 0, extraCount, minSize+1);  // lists with extra nodes
        AddNodes(ans, head, extraCount, k, minSize);    // lists with min nodes

        return ans;
    }

    private ListNode AddNodes(ListNode[] ans, ListNode head, int start, int end, int minSize){
        for(var ansIdx=start; ansIdx < end && head != null; ansIdx++){
            ans[ansIdx] = head;
            var prev = head;
            for(var i=0; i<minSize; i++){
                prev = head;
                head = head.next;
            }

            prev.next = null;
        }

        return head;
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