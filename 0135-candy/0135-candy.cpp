class Solution {
public:
    int candy(vector<int>& ratings) {
        auto n = ratings.size();
        vector<int> candies(n, 1);  // Give 1 candy to everyone initially

        // Person with higher rating than immediate left should have more
        for(int i = 1; i < n; ++i)
            if (ratings[i] > ratings[i - 1])
                candies[i] = candies[i - 1] + 1;

        // Person with higher rating than immediate right should have more candy
        auto count = candies[n - 1];
        for(int i = n - 2; i >= 0; --i) {
            if(ratings[i] > ratings[i + 1])
                candies[i] = max(candies[i], candies[i + 1] + 1);
            count += candies[i];
        }

        return count;
    }
};