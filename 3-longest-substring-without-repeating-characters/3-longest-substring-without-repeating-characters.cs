public class Solution {
    public int LengthOfLongestSubstring(string s) {
        if(s.Length == 0) return 0;
        if(s.Length == 1) return 1;
        const int LIMIT = 256;
        var visited = new bool[LIMIT];
        int max = 0, left = 0, right = 0, n = s.Length;   
        do{
            var ch = s[right];
            // keep removing from left till duplicate is gone
            while(visited[ch]){
                visited[s[left]] = false;
                left++;
            }
            visited[ch] = true;
            max = Math.Max(max, right-left+1);
            right++;
        }while(left < n && right < n);
        return max;
    }
}

// Accepted
public class SolutionSet {
    public int LengthOfLongestSubstring(string s) {
        if(s.Length == 0) return 0;
        
        var set = new HashSet<char>();
        int maxlen = 0, l=0, r=0;
        while(r < s.Length){
            // if char at r index is new
            if(set.Add(s[r])){
                r++;
                continue;
            }
            // if it is repeated, then keep removing chars from left of string
            maxlen = Math.Max(maxlen, r-l);
            do{
                set.Remove(s[l]);
                l++;
            }while(!set.Add(s[r]));
            r++;
        }
        
        maxlen = Math.Max(maxlen, r-l);
        return maxlen;
    }
}