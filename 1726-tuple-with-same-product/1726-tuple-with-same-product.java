// n^2
class Solution {
    public int tupleSameProduct(int[] nums) {
        int n = nums.length, count = 0;
        var prod = new HashMap<Integer, Integer>();

        for(var i=0; i<n; i++){
            for(var j=i+1; j<n; j++){
                var p = nums[i] * nums[j];
                count += prod.getOrDefault(p, 0) * 8;
                prod.put(p, 1 + prod.getOrDefault(p, 0));
            }
        }

        return count;
    }
}

// Accepted - n^2
class SolutionElaborate {
    public int tupleSameProduct(int[] nums) {
        var n = nums.length;
        var prod = new HashMap<Integer, Integer>();

        for(var i=0; i<n; i++){
            for(var j=i+1; j<n; j++){
                var p = nums[i] * nums[j];
                prod.put(p, 1 + prod.getOrDefault(p, 0));
            }
        }

        // nC2 * (n-1)C2 = (freq * 2) * (freq-1 * 2)
        var count = 0;
        for(var freq : prod.values())
            if(freq > 1)
                count += 4 * freq * (freq-1);
            
        
        return count;
    }
}