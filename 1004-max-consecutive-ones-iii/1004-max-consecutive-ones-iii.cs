public class Solution {
    public int LongestOnes(int[] nums, int k) {
        int n = nums.Length, l = 0, r = 0;
        for(; r<n; r++){
            if(nums[r] == 0) k--;
            if(k < 0 && nums[l++] == 0) k++;
        }

        return r-l;
    }
}

// Accepted
public class SolutionComplex {
    public int LongestOnes(int[] nums, int k) {
        int n = nums.Length, l = 0, r = 0, z = 0, max = 0;
        for(; r<n; r++){
            if(nums[r] == 1) continue;
            if(nums[r] == 0 && z < k){
                z++;
                continue;
            }

            // if nums[r] == 0 && z == k
            max = Math.Max(max, r-l);
            if(nums[l] == 0 && z != 0) z--;
            l++; 
            if(r >= l) r--;
        }

        return Math.Max(max, (r-l));
    }
}