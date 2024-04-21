public class Solution {
    public IList<int> FindAnagrams(string s, string p) {
        var result = new List<int>();
        int slen = s.Length, plen = p.Length;
        if(plen > slen) return result;

        // figure out frequency of each chars in p
        var pfreq = new int[26];
        foreach(var ch in p) pfreq[ch-'a']++;

        // create the window, for sliding later
        int l=0, r=0;
        for(; r<plen; r++){
            var idx = s[r] - 'a';
            pfreq[idx]--;
        }
        if(CheckAllZeros(pfreq)) result.Add(l);

        // start sliding the window
        while(r < slen){
            pfreq[s[l++]-'a']++;
            pfreq[s[r++]-'a']--;
            if(CheckAllZeros(pfreq)) result.Add(l);
        }

        return result;
    }

    private bool CheckAllZeros(int[] freq){
        foreach(var f in freq)
            if(f != 0) return false;
        return true;
    }
}