// if any num is repeated while iterating, then it means that sum of nums in between is divisible by k
class Solution {
    public boolean checkSubarraySum(int[] nums, int k) {
        var n = nums.length;
        var idxMap = new HashMap<Integer, Integer>();
        idxMap.put(0, -1);

        var curr = 0;
        for(var i=0; i<n; i++){
            curr += nums[i];
            curr %= k;

            if(idxMap.containsKey(curr)){
                var prev = idxMap.get(curr);
                if(i - prev > 1)    return true;
            }
            else
                idxMap.put(curr, i);
        }

        return false;
    }
}

// Brute force : O(n^2)
class SolutionBF {
    public boolean checkSubarraySum(int[] nums, int k) {
        var n = nums.length;
        var set = new HashSet<Integer>();
        var maxNum = 0;

        for(var i=0; i<n; i++){
            var curr = nums[i];
            for(var j=i+1; j<n; j++){
                curr += nums[j];
                set.add(curr);
                maxNum = Math.max(maxNum, curr);
            }
        }

        var mul = 1;
        while(k * mul <= maxNum)
            if(set.contains(k * mul++)) return true;
        
        return false;
    }
}