public class Solution {
    public int MinimizeMax(int[] nums, int p) {
        if(p == 0) return 0;
        var n = nums.Length;
        Array.Sort(nums);

        int l = 0, r = nums[n-1] - nums[0];
        while(l < r){
            var mid = l + (r - l) / 2;
            if(HasPairs(nums, p, mid)) r = mid;
            else l = mid + 1;

        }
        return l;
    }

    private bool HasPairs(int[] nums, int p, int maxDiff){
        var count = 0;
        for(var i=0; i<nums.Length-1; i++){
            if(nums[i+1] - nums[i] <= maxDiff){
                i++;    // skip next element also as we included in current
                count++;
                if(count >= p) return true;
            }
        }
        return false;
    }
}