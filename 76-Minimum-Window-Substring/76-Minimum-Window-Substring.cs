// using sliding window and frequency dictionary
// first find the end index where all chars exist, then shift start index to right slowly
public class Solution {
    public string MinWindow(string s, string t) {
        if(t.Length > s.Length || s.Length == 0) return string.Empty;

        // find out frequency of each char in t string
        var freq = new Dictionary<char, int>();
        foreach(var ch in t)
            if(freq.ContainsKey(ch)) freq[ch]++;
            else freq[ch]=1;

        var len = s.Length;
        int left=0, minLeft=0, minLen=len+1, count=0;
        // for each sliding window
        for(var right=0; right<len; right++){
            if(freq.ContainsKey(s[right])){
                freq[s[right]]--;
                if(freq[s[right]] >= 0) count++;
            }

            // count will be same as t.Length if all chars are found in window
            while(count == t.Length){
                if(right-left+1 < minLen){
                    minLen = right-left+1;
                    minLeft = left;
                }
                if(freq.ContainsKey(s[left])){
                    freq[s[left]]++;
                    if(freq[s[left]] > 0) count--;
                }
                left++;
            }
        }

        if(minLen > len) return string.Empty;
        return s.Substring(minLeft, minLen);
    }
}