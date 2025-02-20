// explained here : https://leetcode.com/problems/regular-expression-matching/solutions/191830/java-dp-solution-beats-100-with-explanation/
public class Solution {
    public bool IsMatch(string s, string p) {
        int slen = s.Length, plen = p.Length;
        if(plen == 0) return slen == 0;

        // dp[i,j] = does s string till i  match with p string till j
        var dp = new bool[slen+1, plen+1];
        dp[0,0] = true;     // 0 length string matches with 0 length pattern

        // a '*' can match empty string
        for(var pidx=2; pidx <= plen; pidx++)
            dp[0,pidx] = p[pidx-1] == '*' && dp[0, pidx-2];

        // for each char in s, check how it matches with pattern
        for(var sidx=1; sidx<=slen; sidx++){
            for(var pidx=1; pidx<=plen; pidx++){
                // if exact char matches, or pattern is ".", then it is a match.
                // If all chars were matching till now, then string till now will be marked as true in dp
                if((p[pidx-1] == s[sidx-1]) || p[pidx-1] == '.')
                    dp[sidx, pidx] = dp[sidx-1, pidx-1];
                // if cuurent pattern is "*", then match depends on previous char
                else if(p[pidx-1] == '*')
                    dp[sidx, pidx] = dp[sidx, pidx-2]                                   // '*' is considered as empty
                                 || ((s[sidx-1] == p[pidx-2] || p[pidx-2] == '.')       // '*' is repeating previous char or '.'
                                    && dp[sidx-1, pidx]);                               // making sure that till last step, pattern was matching
            }
        }

        // last index will tell if pattern & string both reached an agreement or not
        return dp[slen, plen];
    }
}