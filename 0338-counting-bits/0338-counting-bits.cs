public class Solution {
    public int[] CountBits(int n) {
        var nums = new List<int>();
        // populate all possible bit setters
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