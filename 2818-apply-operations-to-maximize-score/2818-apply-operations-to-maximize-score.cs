public class Solution {
    public int MaximumScore(IList<int> nums, long k) {
        var n = nums.Count;
        var MOD = 1_000_000_007;

        // calculate prime score for each number
        var primeScore = CalculatePrimeScore(nums);

        // for each index, find out idx of nums on left and right which have higher prime score
        var leftHigh = CalculateLeftHigh(primeScore);
        var rightHigh = CalculateRightHigh(primeScore);

        // sort the nums desc while maintaining idx information
        var numIdx = new int[n][];
        for(var i=0; i<n; i++)
            numIdx[i] = [nums[i], i];
        Array.Sort(numIdx, (n1 , n2) => n2[0] - n1[0]);

        // starting with biggest num
        // find out how many subarrays can we make with it, where it has highest prime score
        long score = 1;
        foreach(var ni in numIdx){
            int num = ni[0], idx = ni[1];
            var left = idx - leftHigh[idx];
            var right = rightHigh[idx] - idx;
            
            var subArrs = (long)left * right;   // cast to long to handle bigger ranges
            subArrs = Math.Min(subArrs, k);
            
            score = (score * Power(num, subArrs, MOD)) % MOD;
            k -= subArrs;
            if(k == 0) break;
        }

        return (int) score;
    }

    private int[] CalculatePrimeScore(IList<int> nums){
        var n = nums.Count;
        var primeScore = new int[n];

        for(var i=0; i<n; i++){
            var num = nums[i];
            for(var div = 2; div <= Math.Sqrt(num); div++){
                if(num % div != 0) continue;
                primeScore[i]++;

                while(num % div == 0) num /= div;
            }

            if(num > 1) primeScore[i]++;    // the remaining prime factor
        }

        return primeScore;
    }

    private int[] CalculateLeftHigh(int[] primeScore){
        var n = primeScore.Length;
        var leftHigh = new int[n];

        var prev = -1;
        for(var i=0; i<n; i++){
            while(prev >= 0 && primeScore[prev] < primeScore[i])
                prev = leftHigh[prev];
            leftHigh[i] = prev;
            prev = i;
        }

        return leftHigh;
    }

    private int[] CalculateRightHigh(int[] primeScore){
        var n = primeScore.Length;
        var rightHigh = new int[n];

        var prev = n;
        for(var i=n-1; i>=0; i--){
            while(prev < n && primeScore[prev] <= primeScore[i])
                prev = rightHigh[prev];
            rightHigh[i] = prev;
            prev = i;
        }

        return rightHigh;
    }

    private long Power(long basee, long exponent, int MOD){
        long res = 1;
        
        while(exponent > 0){
            // if the curr bit is set, then base will be added to result
            if((exponent & 1) == 1)
                res = (res * basee) % MOD;
            
            basee = (basee * basee) % MOD;
            exponent >>= 1; // right shift to process next bit
        }

        return res;
    }
}