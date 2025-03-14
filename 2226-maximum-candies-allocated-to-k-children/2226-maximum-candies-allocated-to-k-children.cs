public class Solution {
    public int MaximumCandies(int[] candies, long k) {
        int low = 0, high = candies.Max();

        while(low < high){
            var mid = low + (high - low + 1) / 2;
            if(CanGive(candies, k, mid))
                low = mid;
            else 
                high = mid - 1;
        }

        return low;
    }

    private bool CanGive(int[] candies, long k, int count){
        if(count == 0) return true;

        for(var i=0; i<candies.Length && k > 0; i++)
            k -= candies[i] / count;

        return k <= 0;
    }
}