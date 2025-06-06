// Easier to follow modular arithmetic
// (x - y) % m = k          // initial equation
// (x % m) - (y % m) = k    // expand equation
// y % m = (x % m) - k      // rearrange

class Solution {
    public long countInterestingSubarrays(List<Integer> nums, int modulo, int k) {
        var n = nums.size();
        long ans = 0;

        // we only care about num % modulo value
        for(var i=0; i<n; i++){
            if(nums.get(i) % modulo == k) nums.set(i, 1);
            else nums.set(i, 0);
        }

        // key = mod value, val = count of indexes with that mod value
        var cntMap = new HashMap<Integer, Integer>();
        cntMap.put(0, 1);

        // count how many subarray ranges have mod = k
        var preSum = 0;
        for(var i=0; i<n; i++){
            preSum += nums.get(i);
            var modVal = preSum % modulo;

            var compliment = modVal - k;
            if(compliment < 0) compliment += modulo;
            ans += cntMap.getOrDefault(compliment, 0);
            
            cntMap.put(modVal, cntMap.getOrDefault(modVal, 0) + 1);
        }

        return ans;
    }
}


// Recap of modular arithmetic
// (x - y) % m = k      // initial equation
// (x - y) ≡ k % m      // both sides are congruent, i.e. they give same value when we do mod with m
// -y ≡ (k - x) % m     // -x on both side
// y ≡ (x - k) % m      // multiply by -1 on both side
// y = (x + m - k) % m  // add m to x to avoid negative value when x < k. This will have no effect on mod

class SolutionWorking {
    public long countInterestingSubarrays(List<Integer> nums, int modulo, int k) {
        var n = nums.size();
        long ans = 0;

        // we only care about num % modulo value
        for(var i=0; i<n; i++){
            if(nums.get(i) % modulo == k) nums.set(i, 1);
            else nums.set(i, 0);
        }

        // key = mod value, val = count of indexes with that mod value
        var cntMap = new HashMap<Integer, Integer>();
        cntMap.put(0, 1);

        // count how many subarray ranges have mod = k
        var preSum = 0;
        for(var i=0; i<n; i++){
            preSum += nums.get(i);
            var preMod = (preSum + modulo - k) % modulo;
            ans += cntMap.getOrDefault(preMod, 0);
            
            var key = preSum % modulo;
            cntMap.put(key, cntMap.getOrDefault(key, 0) + 1);
        }

        return ans;
    }
}