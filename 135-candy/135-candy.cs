public class Solution {
    public int Candy(int[] ratings) {
        var n = ratings.Length;
        var candies = Enumerable.Repeat(1, n).ToArray();    // initialise array with 1
        
        // traverse from left to right
        for(var i=1; i<n; i++){
            if(ratings[i] > ratings[i-1])
                candies[i] = candies[i-1] + 1;
        }
        
        // traverse from right to left
        for(var i=n-2; i>=0; i--){
            if(ratings[i] > ratings[i+1])
                // if candie count is already high while coming from left, then we won't change it
                candies[i] = Math.Max(candies[i], candies[i+1] + 1);
        }
        
        return candies.Sum();
    }
}