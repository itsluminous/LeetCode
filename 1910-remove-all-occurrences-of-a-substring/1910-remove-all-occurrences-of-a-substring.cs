// KMP - O(m + n)
public class Solution {
    public string RemoveOccurrences(string s, string part) {
        int sLen = s.Length, pLen = part.Length;
        var lps = ComputeLPS(part);
        var sb = new StringBuilder();           // to track seen chars in s
        var matchingChars = new int[sLen+1];    // count matching chars in part till any idx

        // look for match using KMP
        for(int sIdx = 0, pIdx = 0; sIdx < sLen; sIdx++){
            var curr = s[sIdx];
            sb.Append(curr);

            // if char in s & part match
            if(curr == part[pIdx]){
                matchingChars[sb.Length] = ++pIdx;

                // if complete part match is found, remove it from sb
                if(pIdx == pLen){
                    sb.Length -= pLen;

                    // point pIdx to next lookup in part string
                    pIdx = sb.Length == 0 ? 0 : matchingChars[sb.Length];
                }
            }
            // backtrack in case curr char does not match
            else if(pIdx != 0){
                pIdx = lps[pIdx - 1];
                // the curr char in s will be processed again
                sb.Length--;
                sIdx--;
            }
            // restart match from part[0]
            else
                matchingChars[sb.Length] = 0;
        }

        return sb.ToString();
    }

    private int[] ComputeLPS(string pattern){
        var n = pattern.Length;
        var lps = new int[n];

        for(int curr = 1, len = 0; curr < n; curr++){
            // if chars match, extend prefix length
            if(pattern[curr] == pattern[len])
                lps[curr] = ++len;
            // if chars don't match, backtrack one step
            else if(len != 0){
                len = lps[len - 1];
                curr--;
            }
            // if there is no backtracking possible, restart matching
            else
                lps[curr] = 0;
        }

        return lps;
    }
}

// Accepted - O(m * n)
public class SolutionSimple {
    public string RemoveOccurrences(string s, string part) {
        var pLen = part.Length;
        var sb = new StringBuilder();
        
        foreach(var ch in s){
            sb.Append(ch);
            if(sb.Length >= pLen){
                var temp = sb.ToString().Substring(sb.Length - pLen, pLen);
                if(temp == part)
                    sb.Length -= pLen;
            }
        }

        return sb.ToString();
    }
}