// n^2
public class Solution {
    public int TupleSameProduct(int[] nums) {
        int n = nums.Length, count = 0;
        var prod = new Dictionary<int, int>();

        for(var i=0; i<n; i++){
            for(var j=i+1; j<n; j++){
                var p = nums[i] * nums[j];
                if(prod.ContainsKey(p))
                    count += prod[p]++;
                else
                    prod[p] = 1;
            }
        }

        return count * 8;
    }
}

// Accepted - n^2
public class SolutionElaborate {
    public int TupleSameProduct(int[] nums) {
        var n = nums.Length;
        var prod = new Dictionary<int, int>();

        for(var i=0; i<n; i++){
            for(var j=i+1; j<n; j++){
                var p = nums[i] * nums[j];
                if(prod.ContainsKey(p)) prod[p]++;
                else prod[p] = 1;
            }
        }

        // nC2 * (n-1)C2 = (freq * 2) * (freq-1 * 2)
        var count = 0;
        foreach(var freq in prod.Values)
            if(freq > 1)
                count += 4 * freq * (freq-1);
            
        
        return count;
    }
}