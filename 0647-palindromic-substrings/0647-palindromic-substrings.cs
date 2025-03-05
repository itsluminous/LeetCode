// DP with less loops
public class Solution {
    public int CountSubstrings(string s) {
        int n = s.Length, count = 0;
        var dp = new bool[n,n];  // to check if string with given start & end is palindrome index
        
        for(var len=1; len<=n; len++){
            for(int start=0, end=start+len-1; end<n; start++, end++){
                if((len <= 2 ||  dp[start+1,end-1]) && s[start] == s[end]){
                    dp[start,end] = true;
                    count++;
                }
            }
        }

        return count;
    }
}

// Accepted - DP
public class SolutionDP {
    public int CountSubstrings(string s) {
        int n = s.Length, count = s.Length;
        var dp = new bool[n,n];  // to check if string with given start & end is palindrome index
        for(var i=0; i<n; i++) dp[i,i] = true;  // single char is always palindrome
        // if 2 consecutive chars is same, then mark it as palindrome
        for(var i=0; i<n-1; i++){
            if(s[i] == s[i+1]){
                dp[i,i+1] = true;
                count++;
            }
        }
        
        // now check for string length >= 3
        for(var len=3; len<=n; len++){
            for(int start=0, end=start+len-1; end<n; start++, end++){
                if(dp[start+1,end-1] && s[start] == s[end]){
                    dp[start,end] = true;
                    count++;
                }
            }
        }

        return count;
    }
}

// Accepted - Idea is that for each character, expand on both sides
public class SolutionExpand {
    public int CountSubstrings(string s) {
        var count = 0;
        for(var i=0; i<s.Length; i++){
            count += CountPallindromes(s, i, i);    // odd length
            count += CountPallindromes(s, i, i+1);  // even length
        }
        return count;
    }
    
    private int CountPallindromes(string s, int left, int right){
        var count = 0;
        while(left >=0 && right < s.Length && s[left] == s[right]){
            count++;
            left--;
            right++;
        }
        return count;
    }
}