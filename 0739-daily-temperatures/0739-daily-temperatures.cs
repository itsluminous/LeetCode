// Without using extra space
public class Solution {
    public int[] DailyTemperatures(int[] temp) {
        var n = temp.Length;
        var wait = new int[n];
        wait[n-1] = 0;

        for(var i=n-2; i>=0; i--){
            var idx = i+1;
            while(idx < n){
                // found a temp greater than current
                if(temp[idx] > temp[i]){
                    wait[i] = idx-i;
                    break;
                }
                // case where bigger temp does not exist
                if(wait[idx] == 0){
                    idx = n;
                    break;
                }
                // find next bigger temp
                idx += wait[idx];
            }
            if(idx == n) wait[i] = 0;
        }

        return wait;
    }
}

// Accepted - using stack
public class SolutionStack {
    public int[] DailyTemperatures(int[] temperatures) {
        var n = temperatures.Length;
        var stack = new Stack<int>();
        var wait = new int[n];

        for(var curr=0; curr<n; curr++){
            while(stack.Count > 0 && temperatures[stack.Peek()] < temperatures[curr]){
                var prev = stack.Pop();
                wait[prev] = curr-prev;
            }
            stack.Push(curr);
        }

        return wait;
    }
}