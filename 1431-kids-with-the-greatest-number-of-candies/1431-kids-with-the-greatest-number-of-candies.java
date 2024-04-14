public class Solution {
    public List<Boolean> kidsWithCandies(int[] candies, int extraCandies) {
        var max = Arrays.stream(candies).max().getAsInt();
        
        var n = candies.length;
        var ans = new ArrayList<Boolean>(n);
        for(var i=0; i<n; i++)
            if(candies[i] + extraCandies >= max) ans.add(true);
            else ans.add(false);

        return ans;
    }
}