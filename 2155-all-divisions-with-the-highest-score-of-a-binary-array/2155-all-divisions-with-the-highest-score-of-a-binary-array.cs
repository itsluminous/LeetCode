public class Solution {
    public IList<int> MaxScoreIndices(int[] nums) {
        int zeroes = 0, oneSum = 0, zeroSum = 0;
        
        // count sum of all ones
        foreach(var num in nums) oneSum += num;
        
        // when starting at index 0, score will be sum of all ones
        var maxScore = oneSum;
        var result = new List<int>();
        result.Add(0);
        
        // partition from index 1 onwards and check value
        for(var i=1; i<=nums.Length; i++){
            if(nums[i-1] == 0) zeroSum++;
            else oneSum--;
            
            var curr = oneSum+zeroSum;
            if(curr == maxScore)
                result.Add(i);
            else if(curr > maxScore){
                result = new List<int>();
                result.Add(i);
                maxScore = curr;
            }
        }
        
        return result;
    }
}