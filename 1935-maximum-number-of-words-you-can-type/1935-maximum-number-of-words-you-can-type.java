class Solution {
    public int canBeTypedWords(String text, String brokenLetters) {
        var broken = new int[26];   // 1 if broken, 0 if not
        for(var ch : brokenLetters.toCharArray())
            broken[ch - 'a'] = 1;
        
        int ans = 0, curr = 0;
        for(var ch : text.toCharArray()){
            if(ch == ' '){
                if(curr == 0) ans++;
                curr = 0;
            }
            else
                curr += broken[ch - 'a'];
        }
        
        if(curr == 0) ans++;
        return ans;
    }
}

// Accepted - slow
class Solution1 {
    public int canBeTypedWords(String text, String brokenLetters) {
        var words = text.split(" ");
        var broken = 0;

        for(var word : words){
            for(var ch : brokenLetters.toCharArray()){
                if(word.contains(String.valueOf(ch))){
                    broken++;
                    break;
                }
            }
        }

        return words.length - broken;
    }
}