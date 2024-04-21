public class Solution {
    public List<Integer> findAnagrams(String s, String p) {
        var result = new ArrayList<Integer>();
        int slen = s.length(), plen = p.length();
        if(plen > slen) return result;

        // figure out frequency of each chars in p
        var pfreq = new int[26];
        for(var ch : p.toCharArray()) pfreq[ch-'a']++;

        // create the window, for sliding later
        int l=0, r=0;
        var schars = s.toCharArray();
        for(; r<plen; r++){
            var idx = schars[r] - 'a';
            pfreq[idx]--;
        }
        if(checkAllZeros(pfreq)) result.add(l);

        // start sliding the window
        while(r < slen){
            pfreq[schars[l++]-'a']++;
            pfreq[schars[r++]-'a']--;
            if(checkAllZeros(pfreq)) result.add(l);
        }

        return result;
    }

    private boolean checkAllZeros(int[] freq){
        for(var f : freq)
            if(f != 0) return false;
        return true;
    }
}