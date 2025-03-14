class Solution {
    public int maximumCandies(int[] candies, long k) {
        int low = 0, high = 1 + Arrays.stream(candies).max().getAsInt();

        while(low < high){
            var mid = low + (high - low) / 2;
            if(canGive(candies, k, mid))
                low = mid + 1;
            else 
                high = mid;
        }

        return low - 1;
    }

    private boolean canGive(int[] candies, long k, int count){
        if(count == 0) return true;

        for(var i=0; i<candies.length && k > 0; i++)
            k -= candies[i] / count;

        return k <= 0;
    }
}