public class Solution {
    public int pairSum(ListNode head) {
        // find mid
        ListNode slow = head, fast = head.next;
        while(fast != null && fast.next != null){
            fast = fast.next.next;
            slow = slow.next;
        }

        var mid = slow.next;
        
        // save all numbers till mid in stack
        var stack = new Stack<Integer>();
        var curr = head;
        do{
            stack.push(curr.val);
            curr = curr.next;
        }while(curr != mid);

        // get twin sum for all numbers and update max
        var maxSum = 0;
        do{
            var sum = curr.val + stack.pop();
            maxSum = Math.max(maxSum, sum);
            curr = curr.next;
        }while(curr != null);

        return maxSum;
    }
}