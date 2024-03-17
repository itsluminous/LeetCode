public class Solution {
    Dictionary<int,int> frequencyCount;
    public int MinimumDeletions(string word, int k) {
        var dict = new Dictionary<char, int>();
        foreach(var ch in word)
            if(dict.ContainsKey(ch)) dict[ch]++;
            else dict[ch] = 1;
        
        var freq = dict.Values.ToList();
        freq.Sort();
        
        return Convert.ToInt32(Delete(freq, 0, freq.Count-1, k));
    }
    
    private long Delete(List<int> freq, int lIdx, int rIdx, int k){
        var (l,r) = (freq[lIdx], freq[rIdx]);
        if(r-l <= k) return 0;

        var leftDelete = l + Delete(freq, lIdx+1, rIdx, k);
        var rightDelete = (r-l-k) + Delete(freq, lIdx, rIdx-1, k);
        var min = Math.Min(leftDelete, rightDelete);
        return min;
    }
}