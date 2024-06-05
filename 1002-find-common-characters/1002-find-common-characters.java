class Solution {
    public List<String> commonChars(String[] words) {
        // count occurrence of all chars in first word
        var prev = new int[26];
        for(var ch : words[0].toCharArray())
            prev[ch-'a']++;
        
        // count occurrence of all common chars in other strings
        for(var i=1; i<words.length; i++){
            var curr = new int[26];
            for(var ch : words[i].toCharArray())
                curr[ch-'a'] = Math.min(prev[ch-'a'], curr[ch-'a'] + 1);
            prev = curr;
        }

        // find all chars that are common, along with frequency
        var ans = new ArrayList<String>();
        for(var i=0; i<26; i++)
            for(var j=0; j<prev[i]; j++)
                ans.add(Character.toString((char)('a' + i)));
        
        return ans;
    }
}