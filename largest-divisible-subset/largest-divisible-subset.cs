// Same solution as Longest Increasing Subsequence
public class Solution {
    public IList<int> LargestDivisibleSubset(int[] nums) {
        // Sort nums so that all numbers on left are the only possible divisors
        Array.Sort(nums);
        
        var n = nums.Length;
        var lis = new int[n];   // this tells what is max subset count till here
        var prev = new int[n];  // this tells what is prev number for index i which is part of subset
        int max = 0, maxIdx = -1;   // track max subset count so that we can later backtrack to form result
        
        for(var i=0; i<n; i++){
            lis[i] = 1;     // only one item part of this subset
            prev[i] = -1;   // no previous element part of this subset
            for(var j=i-1; j>=0; j--){
                if(nums[i] % nums[j] == 0 && lis[j]+1 > lis[i]){
                    lis[i] = lis[j]+1;
                    prev[i] = j;
                }
            }
            if(lis[i] > max){
                max = lis[i];
                maxIdx = i;
            }
        }
        
        // Now pick max index and start backtracking to form resultant subset
        var result = new List<int>();
        while(maxIdx != -1){
            result.Add(nums[maxIdx]);
            maxIdx = prev[maxIdx];
        }
        
        return result;
    }
}