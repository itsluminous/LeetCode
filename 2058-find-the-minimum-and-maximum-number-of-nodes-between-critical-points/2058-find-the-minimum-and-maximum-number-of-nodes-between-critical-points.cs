public class Solution {
    public int[] NodesBetweenCriticalPoints(ListNode head) {
        int prevVal = head.val;
        int first = -1, prev = -1;  // index of critical points
        var ans = new int[]{int.MaxValue, -1};

        head = head.next;
        for(var curr=1; head.next != null; curr++, head = head.next){
            if((prevVal > head.val && head.val < head.next.val) ||    // minima
               (prevVal < head.val && head.val > head.next.val)){     // maxima
               // if this is first encounter of critical point
                if(prev == -1)
                    first = prev = curr;
                else{
                    ans[0] = Math.Min(ans[0], curr - prev);
                    ans[1] = Math.Max(ans[1], curr - first);
                    prev = curr;
                }
            }
            prevVal = head.val;
        }

        if(ans[1] == -1) ans[0] = -1;   // not enough critical points found
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