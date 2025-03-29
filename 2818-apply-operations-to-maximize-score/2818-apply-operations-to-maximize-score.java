class Solution {
    public int maximumScore(List<Integer> nums, int k) {
        var n = nums.size();
        var MOD = 1_000_000_007;

        // calculate prime score for each number
        var primeScore = calculatePrimeScore(nums);

        // for each index, find out idx of nums on left and right which have higher prime score
        var leftHigh = calculateLeftHigh(primeScore);
        var rightHigh = calculateRightHigh(primeScore);

        // sort the nums desc while maintaining idx information
        var numIdx = new int[n][2];
        for(var i=0; i<n; i++)
            numIdx[i] = new int[]{nums.get(i), i};
        Arrays.sort(numIdx, (n1 , n2) -> n2[0] - n1[0]);

        // starting with biggest num
        // find out how many subarrays can we make with it, where it has highest prime score
        long score = 1;
        for(var ni : numIdx){
            int num = ni[0], idx = ni[1];
            var left = idx - leftHigh[idx];
            var right = rightHigh[idx] - idx;
            
            var subArrs = (long)left * right;   // cast to long to handle bigger ranges
            subArrs = Math.min(subArrs, k);
            
            score = (score * power(num, subArrs, MOD)) % MOD;
            k -= subArrs;
            if(k == 0) break;
        }

        return (int) score;
    }

    private int[] calculatePrimeScore(List<Integer> nums){
        var n = nums.size();
        var primeScore = new int[n];

        for(var i=0; i<n; i++){
            var num = nums.get(i);
            for(var div = 2; div <= Math.sqrt(num); div++){
                if(num % div != 0) continue;
                primeScore[i]++;

                while(num % div == 0) num /= div;
            }

            if(num > 1) primeScore[i]++;    // the remaining prime factor
        }

        return primeScore;
    }

    private int[] calculateLeftHigh(int[] primeScore){
        var n = primeScore.length;
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

    private int[] calculateRightHigh(int[] primeScore){
        var n = primeScore.length;
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

    private long power(long base, long exponent, int MOD){
        long res = 1;
        
        while(exponent > 0){
            // if the curr bit is set, then base will be added to result
            if((exponent & 1) == 1)
                res = (res * base) % MOD;
            
            base = (base * base) % MOD;
            exponent >>= 1; // right shift to process next bit
        }

        return res;
    }
}