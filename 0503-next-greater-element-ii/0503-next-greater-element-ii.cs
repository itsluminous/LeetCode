public class Solution {
    public int[] NextGreaterElements(int[] nums) {
        var n = nums.Length;
        var stack = new Stack<int>();

        // pre-populate entire array in stack to maintain circular traversing
        for(var i=n-1; i>=0; i--)
            stack.Push(nums[i]);
        
        for(var i=n-1; i>=0; i--){
            var curr = nums[i];
            while(stack.Count > 0 && stack.Peek() <= curr)
                stack.Pop();
            
            if(stack.Count == 0)
                nums[i] = -1;
            else
                nums[i] = stack.Peek();
            
            stack.Push(curr);
        }

        return nums;
    }
}