public class Solution {
    public int PairSum(ListNode head) {
        // find mid
        ListNode slow = head, fast = head.next;
        while(fast != null && fast.next != null){
            fast = fast.next.next;
            slow = slow.next;
        }

        var mid = slow.next;
        
        // save all numbers till mid in stack
        var stack = new Stack<int>();
        var curr = head;
        do{
            stack.Push(curr.val);
            curr = curr.next;
        }while(curr != mid);

        // get twin sum for all numbers and update max
        var maxSum = 0;
        do{
            var sum = curr.val + stack.Pop();
            maxSum = Math.Max(maxSum, sum);
            curr = curr.next;
        }while(curr != null);

        return maxSum;
    }
}