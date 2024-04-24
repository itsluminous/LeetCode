// Accepted - populate all numbers which change bits, then figure out answer
public class Solution {
    public int[] CountBits(int n) {
        // populate all possible bit setters
        var nums = new List<int>();
        for(var i=16; i>=0; i--) nums.Add((int)Math.Pow(2, i));

        var ans = new int[n+1];
        for(var i=0; i<=n; i++){
            var curr = i;
            for(var j=0; j<nums.Count && curr>0; j++){
                // early exit in case we found a scenario which is already evaluated
                if(ans[curr] > 0){
                    ans[i] += ans[curr];
                    break;
                }
                // else, keep checking for when we find next bit
                if(curr >= nums[j]){
                    curr -= nums[j];
                    ans[i]++;
                }
            }
        }

        return ans;
    }
}

// using Brian Kernighan’s Algorithm
public class SolutionBKA {
    public int[] CountBits(int n) {
        var result = new int[n+1];
        for(var i=0; i<=n; i++){
            result[i] = CountSetBits(i);
        }
        return result;
    }
    
    // Brian Kernighan’s Algorithm
    // the loop runs only for as many set bits we have
    private int CountSetBits(int n){
        var count = 0;
        while(n > 0){
            n &= (n-1);
            count++;
        }
        return count;
    }
}

