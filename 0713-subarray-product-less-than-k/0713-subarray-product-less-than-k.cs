// Sliding window
public class Solution {
    public int NumSubarrayProductLessThanK(int[] nums, int k) {
        int n = nums.Length, count = 0, product = 1;
        for(int l=0, r=0; r<n; r++){
            product *= nums[r];
            // whenever product is >= k, then we shift the l pointer to right
            while(product >= k && l<=r)
                product /= nums[l++];
            count += r-l+1;     // these are all combinations between current l and r
        }
        return count;
    }
}

// Accepted - Sliding window with more detailed steps
public class SolutionSliding {
    public int NumSubarrayProductLessThanK(int[] nums, int k) {
        int n = nums.Length, left = 0, right = 1, ans = 0;

        // find the first number <= k
        while(left < n && nums[left] >= k){
            left++; right++;
        }

        if(left == n) return 0; // no number is smaller than k
        ans++;                  // at least one number at idx `left` is smaller than k

        // now start sliding window
        long prod = nums[left];
        while(right < n){
            // if the new number on right is big, then of course it cannot be added in any set
            if(nums[right] >= k){
                right++;
                left = right;
                prod = 1;
                continue;
            }

            // shift the left side if needed
            while(prod * nums[right] >= k){
                prod /= nums[left++];
            }

            // make sure that left is always <= right
            if(left > right) right = left;

            // now figure out how many new sets are possible due to this new permutation of left & right
            prod *= nums[right];
            var len = right-left+1;
            ans += len;
            right++;
        }

        return ans;
    }
}

// Accepted
public class SolutionBruteForce {
    public int NumSubarrayProductLessThanK1(int[] nums, int k) {
        var result = 0;
        var n = nums.Length;
        // pick each number as starting point
        for(int i=0; i<n; i++){
            var curr = nums[i];
            var j=i;
            // try to pair the starting number with others
            while(curr < k){
                result++;
                if(++j < n)
                    curr *= nums[j];
                else
                    break;
            }
        }
        
        return result;
    }
}