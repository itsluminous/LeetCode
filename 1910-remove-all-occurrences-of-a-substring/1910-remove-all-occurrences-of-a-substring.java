// KMP - O(m + n)
class Solution {
    public String removeOccurrences(String s, String part) {
        int sLen = s.length(), pLen = part.length();
        var lps = computeLPS(part);
        var sb = new StringBuilder();           // to track seen chars in s
        var matchingChars = new int[sLen+1];    // count matching chars in part till any idx

        // look for match using KMP
        for(int sIdx = 0, pIdx = 0; sIdx < sLen; sIdx++){
            var curr = s.charAt(sIdx);
            sb.append(curr);

            // if char in s & part match
            if(curr == part.charAt(pIdx)){
                matchingChars[sb.length()] = ++pIdx;

                // if complete part match is found, remove it from sb
                if(pIdx == pLen){
                    sb.delete(sb.length() - pLen, sb.length());

                    // point pIdx to next lookup in part string
                    pIdx = sb.length() == 0 ? 0 : matchingChars[sb.length()];
                }
            }
            // backtrack in case curr char does not match
            else if(pIdx != 0){
                pIdx = lps[pIdx - 1];
                // the curr char in s will be processed again
                sb.deleteCharAt(sb.length()-1);
                sIdx--;
            }
            // restart match from part[0]
            else
                matchingChars[sb.length()] = 0;
        }

        // remaining chars in sb is the answer
        return sb.toString();
    }

    private int[] computeLPS(String pattern){
        var n = pattern.length();
        var lps = new int[n];

        for(int curr = 1, len = 0; curr < n; curr++){
            // if chars match, extend prefix length
            if(pattern.charAt(curr) == pattern.charAt(len))
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
class SolutionSimple {
    public String removeOccurrences(String s, String part) {
        var pLen = part.length();
        var sb = new StringBuilder();
        
        for(var ch : s.toCharArray()){
            sb.append(ch);
            if(sb.length() >= pLen){
                var temp = sb.substring(sb.length() - pLen, sb.length());
                if(temp.equals(part))
                    sb.delete(sb.length() - pLen, sb.length());
            }
        }

        return sb.toString();
    }
}