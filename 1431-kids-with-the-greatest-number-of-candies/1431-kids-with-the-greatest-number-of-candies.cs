public class Solution {
    public IList<bool> KidsWithCandies(int[] candies, int extraCandies) {
        var max = candies.Max();
        
        var n = candies.Length;
        var ans = new bool[n];
        for(var i=0; i<n; i++)
            if(candies[i] + extraCandies >= max)
                ans[i] = true;

        return ans;
    }
}