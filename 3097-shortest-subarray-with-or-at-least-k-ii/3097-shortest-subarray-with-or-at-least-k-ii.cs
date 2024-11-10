public class Solution {
    public int MinimumSubarrayLength(int[] nums, int k) {
        int n = nums.Length, minLen = int.MaxValue, currOr = 0;
        var bitCount = new int[32];

        for(int l=0, r=0; r<n; r++){
            // base case
            if(nums[r] >= k) return 1;

            // update cumulative OR
            currOr = AddNumToOr(nums[r], currOr, bitCount);
            
            // shift left pointer till OR stops matching
            while(currOr >= k){
                minLen = Math.Min(minLen, r - l + 1);
                currOr = RemoveNumFromOr(nums[l++], currOr, bitCount);
            }
        }
        
        if(minLen == int.MaxValue) return -1;
        return minLen;
    }

    private int RemoveNumFromOr(int num, int currOr, int[] bitCount){
        for(var b=0; b<32 && num > 0; b++){
            bitCount[b] -= num & 1;
            num >>= 1;

            if(bitCount[b] == 0)
                currOr &= (~(1 << b));
        }

        return currOr;
    }

    private int AddNumToOr(int num, int currOr, int[] bitCount){
        currOr |= num;
        for(var b=0; b<32 && num > 0; b++){
            bitCount[b] += num & 1;
            num >>= 1;
        }

        return currOr;
    }
}