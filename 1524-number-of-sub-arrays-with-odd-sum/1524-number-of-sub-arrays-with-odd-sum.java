// Accepted - O(1) space : we only need to know odd/even count from prev step
class Solution {
    public int numOfSubarrays(int[] arr) {
        var MOD = 1_000_000_007;
        int even = 0, odd = 0;  // count no. of odd & even subarrays till any idx
        var ans = 0;

        if(arr[0] % 2 == 0) even = 1;
        else odd = 1;
        ans = odd;

        for(var i=1; i < arr.length; i++){
            var isEven = arr[i] % 2 == 0;
            if(isEven){
                // odd + even = odd, so no change there
                // even + even = even
                even = (1 + even) % MOD;        // add 1 because curr number alone is also even
            }
            else{
                var prevOdd = odd;
                // even + odd = odd
                odd = (1 + even) % MOD;         // add 1 because curr number alone is also odd
                // odd + odd = even 
                even = prevOdd;                 
            }

            // update ans with count of odd subarrays till now
            ans = (ans + odd) % MOD;
        }
        
        return ans;
    }
}