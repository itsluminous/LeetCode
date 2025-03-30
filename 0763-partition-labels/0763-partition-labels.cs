public class Solution {
    public IList<int> PartitionLabels(string s) {
        var n = s.Length;

        // store last occurence of a character
        var last = new int[26];
        for(var i=0; i<n; i++){
            var idx = s[i] - 'a';
            last[idx] = i;
        }

        var ans = new List<int>();
        int start = 0, end = 0;
        for(var i=0; i<n; i++){
            var idx = s[i] - 'a';
            if(end < i) {
                ans.Add(end - start + 1);
                start = i;
            }
            end = Math.Max(end, last[idx]);    
        }

        ans.Add(end - start + 1);
        return ans;
    }
}