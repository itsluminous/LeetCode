public class Solution {
    public IList<int> PartitionLabels(string s) {
        var lastIndex = new int[26];
        var n = s.Length;
        for(var i=0; i<n; i++)
            lastIndex[s[i] - 'a'] = i;
        
        int idx = 0, anchor = 0;
        var result = new List<int>();
        for(var i=0; i<n; i++){
            idx = Math.Max(idx, lastIndex[s[i] - 'a']);
            if(idx == i){
                result.Add(i-anchor+1);
                anchor = i+1;
            }
        }
        
        return result;
    }
}