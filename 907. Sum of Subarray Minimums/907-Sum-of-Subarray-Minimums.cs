// using monotonic stack
public class Solution {
    public int SumSubarrayMins(int[] arr) {
        const int MOD = 1_000_000_000 + 7;
        var n = arr.Length;
        long sum = 0;
        var stack = new Stack<int>();

        for(var i=0; i<=n; i++){
            while(stack.Count > 0 && (i == n || arr[stack.Peek()] > arr[i])){
                // we now find impact caused by the element being popped
                var mid = stack.Pop();
                var left = stack.Count > 0 ? stack.Peek() : -1;
                var right = i;

                long diff = ((mid-left) * (right-mid)) % MOD;
                sum += (arr[mid] * diff) % MOD;
            }
            stack.Push(i);
        }
        
        return (int) (sum % MOD);
    }
}

// Accepted
// using monotonic stack
// maintain sumArr which will tell sum till the given index
public class SolutionFaster {
    public int SumSubarrayMins(int[] arr) {
        const int MOD = 1_000_000_000 + 7;
        var n = arr.Length;
        var stack = new Stack<int>();
        
        var sumArr = new long[n+1];
        sumArr[0] = 0;

        for(var i=0; i<n; i++){
            while(stack.Count > 0 && arr[i] < arr[stack.Peek()])
                stack.Pop();
            
            var j = stack.Count > 0 ? stack.Peek() : -1;
            sumArr[i+1] = sumArr[j+1] + (arr[i]*(i-j));
            stack.Push(i);
        }
        
        return (int) (sumArr.Sum() % MOD);
    }
}



// Timeout
public class SolutionTLE {
    public int SumSubarrayMins(int[] arr) {
        const int MOD = 1_000_000_000 + 7;
        var n = arr.Length;
        
        var sumArr = new int[n];
        for(var i=0; i<n; i++) sumArr[i] = arr[i];
        
        long sum = sumArr.Sum();
        var delta = 1;
        for(var r=1; r<n; r++){
            for(var i=0; i+delta<n; i++){
                sumArr[i] = Math.Min(sumArr[i], arr[i+delta]);
                sum = (sum + sumArr[i]);
            }
            delta++;
        }
        
        return (int) (sum % MOD);
    }
}

// arr     3   1   2   4
// sumArr  3   1   2   4
// sumArr  1   1   2   0
// sumArr  1   1   0   0
// sumArr  1   0   0   0