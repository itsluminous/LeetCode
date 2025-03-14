class Solution {
    public int maximumCandies(int[] candies, long k) {
        int low = 0, high = Arrays.stream(candies).max().getAsInt();

        while(low < high){
            var mid = low + (high - low + 1) / 2;
            if(canGive(candies, k, mid))
                low = mid;
            else 
                high = mid - 1;
        }

        return low;
    }

    private boolean canGive(int[] candies, long k, int count){
        if(count == 0) return true;

        for(var i=0; i<candies.length && k > 0; i++)
            k -= candies[i] / count;

        return k <= 0;
    }
}