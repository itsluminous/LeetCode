public class Solution {
    public bool HasAllCodes(string s, int k) {
        var str = new HashSet<string>();
        for(var i=0; i<=s.Length-k; i++)
            str.Add(s.Substring(i, k));
        
        var expectedCount = (1 << k);   // this is max number possible with k binary digits
        var actualCount = str.Count;

        // if total items in set is not same as max possible, then some numbers are missing
        return expectedCount == actualCount;
    }
}