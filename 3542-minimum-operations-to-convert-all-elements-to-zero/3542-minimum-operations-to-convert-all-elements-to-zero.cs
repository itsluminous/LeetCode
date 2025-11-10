public class Solution {
    public int MinOperations(int[] nums) {
        var steps = 0;
        var stack = new Stack<int>();   // monotonnically increasing stack

        foreach(var num in nums){
            // pop all numbers bigger than curr, as they cannot be grouped with anyone else
            while(stack.Count > 0 && stack.Peek() > num) stack.Pop();
            
            if(num == 0) continue;  // no operation needed for 0
            if(stack.Count > 0 && stack.Peek() == num) continue;   // no extra operation needed for same num
            stack.Push(num);
            steps++;
        }

        return steps;
    }
}