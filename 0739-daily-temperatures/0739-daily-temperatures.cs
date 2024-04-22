public class Solution {
    public int[] DailyTemperatures(int[] temperatures) {
        var stack = new Stack<int>();
        var n = temperatures.Length;
        var ans = new int[n];

        for(var i=0; i<n; i++){
            while(stack.Count > 0 && temperatures[stack.Peek()] < temperatures[i]){
                var idx = stack.Pop();
                ans[idx] = i-idx;
            }
            stack.Push(i);
        }

        return ans;
    }
}