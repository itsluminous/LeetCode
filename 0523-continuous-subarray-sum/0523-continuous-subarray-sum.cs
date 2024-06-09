// if any num is repeated while iterating, then it means that sum of nums in between is divisible by k
class Solution {
    public bool CheckSubarraySum(int[] nums, int k) {
        var n = nums.Length;
        var idxMap = new Dictionary<int, int>();
        idxMap[0] = -1;

        var curr = 0;
        for(var i=0; i<n; i++){
            curr += nums[i];
            curr %= k;

            if(idxMap.ContainsKey(curr)){
                var prev = idxMap[curr];
                if(i - prev > 1)  return true;
            }
            else
                idxMap[curr] = i;
        }

        return false;
    }
}