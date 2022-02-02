public class Solution {
    public IList<int> FindAnagrams(string s, string p) {
        var pChars = new int[26];
        var result = new List<int>();
        if(s.Length < p.Length) return result;
        
        // count occurence of each char in p
        foreach(var ch in p) pChars[ch-'a']++;
        int l = 0, r = p.Length;    // limits of sliding window
        for(var i=0; i<r; i++) pChars[s[i]-'a']--;
        CheckZeroes(pChars, result, l);
        
        while(r < s.Length){
            pChars[s[r]-'a']--;
            pChars[s[l]-'a']++;
            CheckZeroes(pChars, result, l+1);
            l++; r++;
        }
        
        return result;
    }
    
    private void CheckZeroes(int[] pChars, List<int> result, int idx){
        foreach(var val in pChars)
            if(val != 0) return;
        result.Add(idx);
    }
}