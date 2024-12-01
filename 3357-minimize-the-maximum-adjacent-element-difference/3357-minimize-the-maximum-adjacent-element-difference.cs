// explaination : https://leetcode.com/problems/minimize-the-maximum-adjacent-element-difference/solutions/6054022/binary-search/
public class Solution {
    public int MinDifference(int[] nums) {
        int n = nums.Length, maxGap = 0, minNum = int.MaxValue, maxNum = 0;
        for(var i=0; i<n-1; i++){
            // if one of the two neighbours is -1 (missing)
            if(Math.Min(nums[i], nums[i+1]) == -1 && Math.Max(nums[i], nums[i+1]) != -1){
                minNum = Math.Min(minNum, Math.Max(nums[i], nums[i+1]));
                maxNum = Math.Max(maxNum, Math.Max(nums[i], nums[i+1]));
            }
            else
                maxGap = Math.Max(maxGap, Math.Abs(nums[i] - nums[i+1]));
        }

        // try different permutations of delta using binary search to get optimal ans
        int l = maxGap, r = (maxNum - minNum + 1) / 2;
        while(l < r){
            var delta = (l + r) / 2;
            if(CheckDiff(nums, minNum + delta, maxNum - delta, delta))
                r = delta;
            else
                l = delta + 1;
        }

        return l;
    }

    // I am not completely clear on the logic in this
    private bool CheckDiff(int[] nums, int x, int y, int delta){
        int n = nums.Length, prev = 0, count = 0;
        for(var i=0; i<n; i++){
            // if curr idx is missing number
            if(nums[i] == -1){
                if(prev > 0 && Math.Min(Math.Abs(prev - x), Math.Abs(prev - y)) > delta)
                    return false;
                count++;
            }
            else {
                if(count > 0){
                    var diff = Math.Min(Math.Abs(nums[i] - x), Math.Abs(nums[i] - y));
                    if(prev > 0){
                        var xDiff = Math.Max(Math.Abs(prev - x), Math.Abs(nums[i] - x));
                        var yDiff = Math.Max(Math.Abs(prev - y), Math.Abs(nums[i] - y));
                        diff = Math.Min(xDiff, yDiff);
                    }

                    if(diff > delta && (count == 1 || y - x > delta))
                        return false;
                }
                prev = nums[i];
                count = 0;
            }
        }
        return true;
    }
}