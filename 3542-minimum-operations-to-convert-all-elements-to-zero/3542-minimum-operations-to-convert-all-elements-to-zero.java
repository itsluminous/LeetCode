class Solution {
    public int minOperations(int[] nums) {
        var steps = 0;
        var stack = new Stack<Integer>();   // monotonnically increasing stack

        for(var num : nums){
            // pop all numbers bigger than curr, as they cannot be grouped with anyone else
            while(!stack.isEmpty() && stack.peek() > num) stack.pop();
            
            if(num == 0) continue;  // no operation needed for 0
            if(!stack.isEmpty() && stack.peek() == num) continue;   // no extra operation needed for same num
            stack.push(num);
            steps++;
        }

        return steps;
    }
}