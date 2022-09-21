public class Solution {
    public int[] SumEvenAfterQueries(int[] nums, int[][] queries) {
        var evenSum = 0;
        foreach(var num in nums)
            if(num%2 == 0) evenSum += num;
        
        var result = new int[queries.Length];
        for(var i=0; i<queries.Length; i++){
            var query = queries[i];
            int val = query[0], idx = query[1];
            if(nums[idx] % 2 == 0) evenSum -= nums[idx];
            nums[idx] += val;
            if(nums[idx] % 2 == 0) evenSum += nums[idx];
            result[i] = evenSum;
        }
        
        return result;
    }
}