class Solution {
    public String clearStars(String s) {
        var chars = new ArrayList[26];  // list of indexes which have char i
        var indexes = new HashSet<Integer>();   // list of indexes which have not been removed
        for(var i=0; i<26; i++)
            chars[i] = new ArrayList<Integer>();

        for(var i=0; i<s.length(); i++){
            var ch = s.charAt(i);
            if(ch == '*'){
                for(var c=0; c<26; c++)
                    if(chars[c].size() > 0){
                        var idx = chars[c].get(chars[c].size() - 1);
                        chars[c].remove(chars[c].size() - 1);
                        indexes.remove(idx);
                        break;
                    }
            }
            else{
                chars[ch-'a'].add(i);
                indexes.add(i);
            }
        }

        var ans = new StringBuilder();
        for(var i=0; i<s.length(); i++){
            var ch = s.charAt(i);
            if(indexes.contains(i))
                ans.append(ch);
        }

        return ans.toString();
    }
}