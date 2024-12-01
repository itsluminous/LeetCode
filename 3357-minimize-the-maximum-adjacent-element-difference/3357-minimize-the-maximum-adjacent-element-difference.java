// explaination : https://leetcode.com/problems/minimize-the-maximum-adjacent-element-difference/solutions/6054022/binary-search/
class Solution {
    public int minDifference(int[] nums) {
        int n = nums.length, maxGap = 0, minNum = Integer.MAX_VALUE, maxNum = 0;
        for(var i=0; i<n-1; i++){
            // if one of the two neighbours is -1 (missing)
            if(Math.min(nums[i], nums[i+1]) == -1 && Math.max(nums[i], nums[i+1]) != -1){
                minNum = Math.min(minNum, Math.max(nums[i], nums[i+1]));
                maxNum = Math.max(maxNum, Math.max(nums[i], nums[i+1]));
            }
            else
                maxGap = Math.max(maxGap, Math.abs(nums[i] - nums[i+1]));
        }

        // try different permutations of delta using binary search to get optimal ans
        int l = maxGap, r = (maxNum - minNum + 1) / 2;
        while(l < r){
            var delta = (l + r) / 2;
            if(checkDiff(nums, minNum + delta, maxNum - delta, delta))
                r = delta;
            else
                l = delta + 1;
        }

        return l;
    }

    // I am not completely clear on the logic in this
    private boolean checkDiff(int[] nums, int x, int y, int delta){
        int n = nums.length, prev = 0, count = 0;
        for(var i=0; i<n; i++){
            // if curr idx is missing number
            if(nums[i] == -1){
                if(prev > 0 && Math.min(Math.abs(prev - x), Math.abs(prev - y)) > delta)
                    return false;
                count++;
            }
            else {
                if(count > 0){
                    var diff = Math.min(Math.abs(nums[i] - x), Math.abs(nums[i] - y));
                    if(prev > 0){
                        var xDiff = Math.max(Math.abs(prev - x), Math.abs(nums[i] - x));
                        var yDiff = Math.max(Math.abs(prev - y), Math.abs(nums[i] - y));
                        diff = Math.min(xDiff, yDiff);
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