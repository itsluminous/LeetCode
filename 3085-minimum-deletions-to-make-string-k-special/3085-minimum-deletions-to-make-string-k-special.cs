public class Solution {
    public int MinimumDeletions(string word, int k) {
        var freq = new int[26];
        foreach(var ch in word) freq[ch - 'a']++;

        var uniqFreq = new HashSet<int>(freq);

        var minRemove = int.MaxValue;
        // we assume each freq as smallest in answer, and then check which numbers need to be removed to make it true
        foreach(var minFreq in uniqFreq) {
            if (minFreq == 0) continue;

            int currRemove = 0;
            foreach(var f in freq) {
                if(f < minFreq) currRemove += f;
                else if (f > minFreq + k) currRemove += f - minFreq - k;
            }
            minRemove = Math.Min(minRemove, currRemove);
        }

        return minRemove;
    }
}