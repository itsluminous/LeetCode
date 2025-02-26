// if you plot prefix sum on a graph, then ans would be diff between highest and lowest point
class Solution {
    public int maxAbsoluteSum(int[] nums) {
        int preSum = 0, maxPos = 0, maxNeg = 0;

        for(var num : nums){
            preSum += num;
            maxPos = Math.max(maxPos, preSum);
            maxNeg = Math.min(maxNeg, preSum);
        }

        return maxPos - maxNeg;
    }
}

// Accepted - needs more comparisons
class SolutionBig {
    public int maxAbsoluteSum(int[] nums) {
        int maxAns = 0, currPos = 0, currNeg = 0;

        for(var num : nums){
            if(num > 0){
                currNeg = Math.min(currNeg + num, 0);
                currPos = Math.max(currPos + num, num);
            }
            else{
                currNeg = Math.min(currNeg + num, num);
                currPos = Math.max(currPos + num, 0);
            }

            var maxPosNeg = Math.max(currPos, Math.abs(currNeg));
            maxAns = Math.max(maxAns, maxPosNeg);
        }

        return maxAns;
    }
}