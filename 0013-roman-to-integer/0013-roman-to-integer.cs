public class Solution {
    public int RomanToInt(string s) {
        var dict = new Dictionary<char, int>{
            {'I', 1}, {'V', 5}, {'X', 10}, {'L', 50},
            {'C', 100}, {'D', 500}, {'M', 1000}
        };

        int n = s.Length, ans = 0;
        for(var i=0; i<n-1; i++){
            char curr = s[i], next = s[i+1];
            if(dict[curr] < dict[next])
                ans -= dict[curr];
            else 
                ans += dict[curr];
        }

        return ans + dict[s[n-1]];
    }
}