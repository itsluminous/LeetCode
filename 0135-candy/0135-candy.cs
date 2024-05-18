// Greedy
public class Solution {
    public int Candy(int[] ratings) {
        var n = ratings.Length;
        var candies = Enumerable.Repeat(1, n).ToArray();

        // person with higher rating than immediate left should have more candy
        for(var i=1; i<n; i++)
            if(ratings[i] > ratings[i-1])
                candies[i] = candies[i-1] + 1;
        
        // person with higher rating than immediate right should have more candy
        for(var i=n-2; i>=0; i--)
            if(ratings[i] > ratings[i+1])
                candies[i] = Math.Max(candies[i], candies[i+1] + 1);

        return candies.Sum();
    }
}