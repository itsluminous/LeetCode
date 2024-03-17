public class Solution {
    Dictionary<int,int> frequencyCount;
    public int MinimumDeletions(string word, int k) {
        var dict = new Dictionary<char, int>();
        foreach(var ch in word)
            if(dict.ContainsKey(ch)) dict[ch]++;
            else dict[ch] = 1;
        
        var freq = dict.Values.ToList();
        freq.Sort();
        
        return Delete(freq, 0, freq.Count-1, k);
    }
    
    private int Delete(List<int> freq, int lIdx, int rIdx, int k){
        var (lVal,rVal) = (freq[lIdx], freq[rIdx]);
        if(rVal-lVal <= k) return 0;

        var leftDelete = lVal + Delete(freq, lIdx+1, rIdx, k);
        var rightDelete = (rVal-lVal-k) + Delete(freq, lIdx, rIdx-1, k);
        return Math.Min(leftDelete, rightDelete);
    }
}