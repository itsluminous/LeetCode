// Similar solution as Longest Increasing Subsequence
class Solution {
    public List<Integer> largestDivisibleSubset(int[] nums) {
        var n = nums.length;
        var lis = new int[n];   // longest subset count till curr idx
        var prev = new int[n];  // prev index included in lis ending at index i

        int maxLen = 0, maxIdx = -1;    // track max length of subset and index where it ends
        Arrays.sort(nums);              // sort so that all divisors are on left side

        for(var i=0; i<n; i++){
            lis[i] = 1;     // assume only curr idx is in lis
            prev[i] = -1;   // no prev element in lis

            for(var j=i-1; j>=0; j--){
                if(nums[i] % nums[j] == 0 && lis[j] + 1 > lis[i]){
                    lis[i] = lis[j] + 1;
                    prev[i] = j;
                }
            }

            if(maxLen < lis[i]){
                maxLen = lis[i];
                maxIdx = i;
            }
        }

        // construct answer by backtracking from maxIdx
        var longestSet = new ArrayList<Integer>();
        while(maxIdx != -1){
            longestSet.add(nums[maxIdx]);
            maxIdx = prev[maxIdx];
        }

        return longestSet;
    }
}