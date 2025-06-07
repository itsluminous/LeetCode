class Solution {
    public String clearStars(String s) {
        var ss = s.toCharArray();
        var n = ss.length;
        var removed = new boolean[n];  // to track which indexes are removed from final ans

        // pos will track which all indexes have characters 'a' to 'z'
        Stack<Integer>[] pos = new Stack[26];
        for(var i=0; i<26; i++) pos[i] = new Stack<Integer>();

        for(var i=0; i<n; i++){
            if(ss[i] != '*')
                pos[ss[i] - 'a'].push(i);    // found non '*' char, so save its pos
            else {
                removed[i] = true;          // mark '*' as removed
                // find out the smallest character that can be removed
                for(var ch = 'a'; ch <= 'z'; ch++){
                    if(pos[ch-'a'].isEmpty()) continue;
                    var idx = pos[ch-'a'].pop();    // remove max idx of smallest character
                    removed[idx] = true;
                    break;
                }
            }
        }

        // any idx not marked for removal will be in ans
        var ans = new StringBuilder();
        for(var i=0; i<n; i++)
            if(!removed[i]) ans.append(ss[i]);
        
        return ans.toString();
    }
}