public class Solution {
    public int PossibleStringCount(string word, int k) {
        var MOD = 1_000_000_007;

        // we don't care about the actual alphabets, we only need to know freq of each char sitting together
        var freq = new List<int>();
        var count = 1;
        for(var i = 1; i < word.Length; i++) {
            if(word[i] == word[i - 1])
                count++;
            else{
                freq.Add(count);
                count = 1;
            }
        }
        freq.Add(count);

        // compute the total number of possible original strings, regardless of the minimum length constraint (k)
        // for each freq of repeated characters of length `n`, Alice could have originally typed
        // any number from 1 to n of those characters (e.g., 'aaa' could be 'a', 'aa', or 'aaa')
        // so for each freq, total ways = freq length
        // eg. if word=abbcccaa, possible choices is 1 * 2 * 3 * 2
        long ans = 1;
        foreach(var f in freq)
            ans = (ans * f) % MOD;
        
        // if we already have k or fewer freq, then the shortest possible original string
        // would be of size equal to number of freq (one character per freq).
        // so, no need to filter out shorter strings — return total
        if(freq.Count >= k)
            return (int)ans;

        // now we find all string combinations with length < k and subtract from ans
        // dp will count the number of original strings whose length < k
        // dp[j] = number of ways to construct an original string of length j using i freq
        var dp = new int[k];
        dp[0] = 1;  // empty string with 0 freq

        for(var i = 1; i <= freq.Count; i++){
            var prefix = new int[k+1];
            for(var j = 0; j < k; j++)
                prefix[j+1] = (prefix[j] +  dp[j]) % MOD;

            dp = new int[k];
            for(var j = i; j < k; j++) {
                // for freq i, we want to add a run of at least 1 character and at most min(freq length, j - i + 1)
                // range sum from prefix[j] to prefix[left]
                var left = j - Math.Min(freq[i - 1], j - i + 1);
                dp[j] = (prefix[j] - prefix[left] + MOD) % MOD;
            }
        }

        // sum up the number of ways to form strings of length < k
        var lessThanK = 0;
        foreach(var val in dp)
            lessThanK = (lessThanK + val) % MOD;

        // subtract shorter strings from total to get valid strings with length ≥ k
        return ((int)ans - lessThanK + MOD) % MOD;
    }
}