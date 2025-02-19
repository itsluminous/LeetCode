public class Solution {
    public string GetHappyString(int n, int k) {
        var maxPossible = 3 * Math.Pow(2, n-1);
        if(maxPossible < k) return "";

        // dict to find unused char based on prev value
        var lookup = new Dictionary<char, string>{{'z', "abc"}, {'a', "bc"}, {'b', "ac"}, {'c', "ab"}};

        var ans = new StringBuilder();
        var prev = 'z';

        for(var i=1; ans.Length < n; i++){
            var mul = (int)Math.Pow(2, n-i);
            var q = (k - 1) / mul;      // because k is 1-indexed (1st happy string = 0th in list)
            k = (k - 1) % mul + 1;      // adding 1 to keep k as 1-indexed
            
            var curr = lookup[prev][q];
            ans.Append(curr);
            prev = curr;
        }
            
        return ans.ToString();
    }
}