class Solution {
    public int minimumSubarrayLength(int[] nums, int k) {
        int n = nums.length, minLen = Integer.MAX_VALUE, currOr = 0;
        var bitCount = new int[32];

        for(int l=0, r=0; r<n; r++){
            // base case
            if(nums[r] >= k) return 1;

            // update cumulative OR
            currOr = addNumToOr(nums[r], currOr, bitCount);
            
            // shift left pointer till OR stops matching
            while(currOr >= k){
                minLen = Math.min(minLen, r - l + 1);
                currOr = removeNumFromOr(nums[l++], currOr, bitCount);
            }
        }
        
        if(minLen == Integer.MAX_VALUE) return -1;
        return minLen;
    }

    private int removeNumFromOr(int num, int currOr, int[] bitCount){
        for(var b=0; b<32 && num > 0; b++){
            bitCount[b] -= num & 1;
            num >>= 1;

            if(bitCount[b] == 0)
                currOr &= (~(1 << b));
        }

        return currOr;
    }

    private int addNumToOr(int num, int currOr, int[] bitCount){
        currOr |= num;
        for(var b=0; b<32 && num > 0; b++){
            bitCount[b] += num & 1;
            num >>= 1;
        }

        return currOr;
    }
}