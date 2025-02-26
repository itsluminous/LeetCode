// if you plot prefix sum on a graph, then ans would be diff between highest and lowest point
public class Solution {
    public int MaxAbsoluteSum(int[] nums) {
        int preSum = 0, maxPos = 0, maxNeg = 0;

        foreach(var num in nums){
            preSum += num;
            maxPos = Math.Max(maxPos, preSum);
            maxNeg = Math.Min(maxNeg, preSum);
        }

        return maxPos - maxNeg;
    }
}

// Accepted - needs more comparisons
public class SolutionBig {
    public int MaxAbsoluteSum(int[] nums) {
        int maxAns = 0, currPos = 0, currNeg = 0;

        foreach(var num in nums){
            if(num > 0){
                currNeg = Math.Min(currNeg + num, 0);
                currPos = Math.Max(currPos + num, num);
            }
            else{
                currNeg = Math.Min(currNeg + num, num);
                currPos = Math.Max(currPos + num, 0);
            }

            var maxPosNeg = Math.Max(currPos, Math.Abs(currNeg));
            maxAns = Math.Max(maxAns, maxPosNeg);
        }

        return maxAns;
    }
}