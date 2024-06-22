public class Solution {
    public int NumberOfSubarrays(int[] nums, int k) {
        var n = nums.Length;
        Dictionary<int,  int> prefixSum = new();
        prefixSum.Add(0, 1);

        int currSum = 0, subarrays = 0;
        foreach(var num in nums){
            currSum += (num % 2);
            if(prefixSum.ContainsKey(currSum - k))
                subarrays += prefixSum[currSum - k];
            
            if(prefixSum.ContainsKey(currSum)) prefixSum[currSum]++;
            else prefixSum[currSum] = 1;
        }

        return subarrays;
    }
}