class Solution {
    public String shortestCommonSupersequence(String str1, String str2) {
        var dp = longestCommonSubsequence(str1, str2);

        // backtrack dp to make final supersequence
        var sb = new StringBuilder();
        int idx1 = str1.length(), idx2 = str2.length();

        while(idx1 > 0 && idx2 > 0){
            // if chars match
            if(str1.charAt(idx1-1) == str2.charAt(idx2-1)){
                sb.append(str1.charAt(idx1-1));
                idx1--;
                idx2--;
            }
            // if picking str1's char gave smaller supersequence
            else if(dp[idx1-1][idx2] < dp[idx1][idx2-1])
                sb.append(str1.charAt(--idx1));
            // if picking str2's char gave smaller supersequence
            else
                sb.append(str2.charAt(--idx2));
        }

        // append remaining chars from str1
        while(idx1 > 0)
            sb.append(str1.charAt(--idx1));
        
        // append remaining chars from str2
        while(idx2 > 0)
            sb.append(str2.charAt(--idx2));

        return sb.reverse().toString();
    }

    private int[][] longestCommonSubsequence(String str1, String str2){
        int len1 = str1.length(), len2 = str2.length();

        // dp to store length of longest supersequence for any length of str1 & str2
        var dp = new int[len1+1][len2+1];

        // when str2 is empty, the supersequence len will be equal to len of str1
        for(var i=0; i<=len1; i++)
            dp[i][0] = i;
        
        // when str1 is empty, the supersequence len will be equal to len of str2
        for(var i=0; i<=len2; i++)
            dp[0][i] = i;
        
        // fill DP
        for(var idx1=1; idx1 <= len1; idx1++){
            for(var idx2=1; idx2 <= len2; idx2++) {
                // if chars match, we can use prev diagonal val
                if(str1.charAt(idx1-1) == str2.charAt(idx2-1))
                    dp[idx1][idx2] = 1 + dp[idx1-1][idx2-1];
                // else we need to pick char from either str1 or str2, whichever gives smaller supersequence
                else
                    dp[idx1][idx2] = 1 + Math.min(dp[idx1-1][idx2], dp[idx1][idx2-1]);
            }
        }

        return dp;
    }
}