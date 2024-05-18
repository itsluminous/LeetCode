class Solution {
    public int candy(int[] ratings) {
        var n = ratings.length;
        var candies = new int[n];
        Arrays.fill(candies, 1);

        // person with higher rating than immediate left should have more candy
        for(var i=1; i<n; i++)
            if(ratings[i] > ratings[i-1])
                candies[i] = candies[i-1] + 1;
        
        // person with higher rating than immediate right should have more candy
        var count = candies[n-1];
        for(var i=n-2; i>=0; i--){
            if(ratings[i] > ratings[i+1])
                candies[i] = Math.max(candies[i], candies[i+1] + 1);
            count += candies[i];
        }

        return count;
    }
}