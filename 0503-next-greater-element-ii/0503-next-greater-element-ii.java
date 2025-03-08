class Solution {
    public int[] nextGreaterElements(int[] nums) {
        var n = nums.length;
        var stack = new Stack<Integer>();

        // pre-populate entire array in stack to maintain circular traversing
        for(var i=n-1; i>=0; i--)
            stack.push(nums[i]);
        
        for(var i=n-1; i>=0; i--){
            var curr = nums[i];
            while(!stack.isEmpty() && stack.peek() <= curr)
                stack.pop();
            
            if(stack.isEmpty())
                nums[i] = -1;
            else
                nums[i] = stack.peek();
            
            stack.push(curr);
        }

        return nums;
    }
}