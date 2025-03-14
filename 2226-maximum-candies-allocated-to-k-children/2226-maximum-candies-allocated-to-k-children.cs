public class Solution {
    public int MaximumCandies(int[] candies, long k) {
        int low = 0, high = 1 + candies.Max();

        while(low < high){
            var mid = low + (high - low) / 2;
            if(CanGive(candies, k, mid))
                low = mid + 1;
            else 
                high = mid;
        }

        return low - 1;
    }

    private bool CanGive(int[] candies, long k, int count){
        if(count == 0) return true;

        for(var i=0; i<candies.Length && k > 0; i++)
            k -= candies[i] / count;

        return k <= 0;
    }
}