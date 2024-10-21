public class Solution {
    int count = 0;

    public int MaxUniqueSplit(string s) {
        Split(s, new HashSet<string>(s.Length), 0);
        return count;
    }

    private void Split(string s, HashSet<string> set, int start){
        if(start == s.Length) {
            count = Math.Max(count, set.Count);
            return;
        }

        for(var end=start+1; end<=s.Length; end++){
            var substr = s.Substring(start, end-start);
            if(!set.Add(substr)) continue;
            Split(s, set, end);
            set.Remove(substr);
        }
    }
}