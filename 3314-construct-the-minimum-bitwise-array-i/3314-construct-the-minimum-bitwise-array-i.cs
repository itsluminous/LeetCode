public class Solution {
    public int[] MinBitwiseArray(IList<int> nums) {
        var n = nums.Count;
        var ans = new int[n];

        for(var i=0; i<n; i++){
            var num = nums[i];
            // any even no. will be -1. In our case all are prime, so only checking 2 is enough
            if(num == 2){
                ans[i] = -1;
                continue;
            }
            // find last 1 bit before first 0 (from left)
            // eg. for 100111 (71), ans is 100011 (67) | 100100 (68)
            // so we need to flip 1 at idx 2 from right
            var pos = 0;
            while((num & (1 << pos)) != 0) pos++;   // this gives posn of first 0
            ans[i] = num ^ (1 << (pos-1));          // pos-1 to get posn of 1 before 0
        }
        return ans;
    }
}