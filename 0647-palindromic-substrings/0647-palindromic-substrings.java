// DP with less loops
class Solution {
    public int countSubstrings(String s) {
        int n = s.length(), count = 0;
        var dp = new boolean[n][n];  // to check if string with given start & end is palindrome index
        
        for(var len=1; len<=n; len++){
            for(int start=0, end=start+len-1; end<n; start++, end++){
                if((len <= 2 ||  dp[start+1][end-1]) && s.charAt(start) == s.charAt(end)){
                    dp[start][end] = true;
                    count++;
                }
            }
        }

        return count;
    }
}

// Accepted - DP
class SolutionDP {
    public int countSubstrings(String s) {
        int n = s.length(), count = s.length();
        var dp = new boolean[n][n];  // to check if string with given start & end is palindrome index
        for(var i=0; i<n; i++) dp[i][i] = true;  // single char is always palindrome
        // if 2 consecutive chars is same, then mark it as palindrome
        for(var i=0; i<n-1; i++){
            if(s.charAt(i) == s.charAt(i+1)){
                dp[i][i+1] = true;
                count++;
            }
        }
        
        // now check for string length >= 3
        for(var len=3; len<=n; len++){
            for(int start=0, end=start+len-1; end<n; start++, end++){
                if(dp[start+1][end-1] && s.charAt(start) == s.charAt(end)){
                    dp[start][end] = true;
                    count++;
                }
            }
        }

        return count;
    }
}

// Accepted - Idea is that for each character, expand on both sides
class SolutionExpand {
    public int countSubstrings(String s) {
        var count = 0;
        for(var i=0; i<s.length(); i++){
            count += countPallindromes(s, i, i);    // odd length
            count += countPallindromes(s, i, i+1);  // even length
        }
        return count;
    }
    
    private int countPallindromes(String s, int left, int right){
        var count = 0;
        while(left >=0 && right < s.length() && s.charAt(left) == s.charAt(right)){
            count++;
            left--;
            right++;
        }
        return count;
    }
}