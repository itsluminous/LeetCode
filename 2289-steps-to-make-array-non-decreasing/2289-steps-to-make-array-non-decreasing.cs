public class Solution {
    public int TotalSteps(int[] nums) {
        int max = 0, n = nums.Length;
        var stack = new Stack<(int num, int step)>();  // number, steps to remove it
        stack.Push((nums[0], 0));     // 0 means number won't be removed
        
        for(var i=1; i<n; i++){
            var step = 0;
            while(stack.Count > 0 && stack.Peek().num <= nums[i]){
                // pop elements to maintain a strictly decreasing monotonic stack
                step = Math.Max(step, stack.Peek().step);
                stack.Pop();
            }
            // empty stack means this is largest element so far. counting restarts at 0
            if(stack.Count == 0) step = 0;
             // time required to remove this element is (1 + the max time we've popped from the stack)
            else step++;
            
            max = Math.Max(max, step);
            stack.Push((nums[i], step));
        }
        
        return max;
    }
}